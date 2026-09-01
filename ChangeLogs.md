# 2026.09.01 (2)

## Login.aspx 突出显示 "Sign In With Azure"，提示内部员工优先使用

- `CrownbioHubase/HuData/Login.aspx`：原来的 "Sign In With Azure" 只是账号密码区域下方表格里一个不起眼的普通文字链接，现改为：
  - 移到用户名/密码输入框上方，改造成整行深色按钮 `#azure-signin`（含纯 CSS 绘制的四色 Microsoft 图标），并在按钮上方新增浅蓝底提示框 `#azure-callout`："CrownBio employees, please use **Sign In With Azure** to log in."
  - 按钮与账号密码表单之间新增 "OR" 分隔线 `#divider`
  - 跳转链接（`https://uc.crownbio.com/sysuser/loginazure?...`）本身未改动
  - `#login` 容器 `height` 由固定 `300px` 改为 `auto`，以适应新增内容撑高
- `wwwroot/HuData/Login.aspx` 是发布产物（`.gitignore` 中 `/wwwroot/` 未纳入版本控制），未手动同步，下次发布/生成时会自动更新

---

# 2026.09.01

## 登录验证暂时回退为纯本地 LDAP，UC API 校验逻辑整体注释保留

- `BLLRemote/Rule/ActiveDirectoryConnector.cs`：`IsUserLoggedIn` 方法体中调用 `AuthenticateAgainstUc` 并回退 `IsUserLoggedInViaLdap` 的 try/catch 逻辑（2026.07.22 引入）整体注释掉，方法直接调用 `IsUserLoggedInViaLdap`，登录验证暂不再调用 UC 接口
- `AuthenticateAgainstUc`/`UcUnavailableException`/`IsUserLoggedInViaLdap` 等相关方法未删除，仅 `IsUserLoggedIn` 里的调用点被注释，便于后续恢复
- 待确认项：本次未说明回退原因，如需恢复 UC 校验，取消注释并删除下方的 `IsUserLoggedInViaLdap` 直接调用即可

---

# 2026.07.27

## 登录密码过期时给出精确提示，不再被误判成"密码不正确"

- `BLLRemote/System/ObjectBLL.cs`：`Login` 方法里 AD 校验失败的 `catch (Exception)` 分支，原先统一返回"密码不正确"，现改为先判断 `ex.Message` 是否包含 `password has expired`，命中则返回新增的 `USER_PWD_EXPIRED` 提示，其余情况维持原有"密码不正确"文案
- `BLLRemote/Rule/ActiveDirectoryConnector.cs`：`AuthenticateAgainstUc` 新增对 UC 返回 `message` 的"密码过期"关键字判断（英文 `password`+`expired`、中文"密码"+"过期"），命中后统一抛出与本地 LDAP（AD 扩展错误码 `532`）一致措辞的 `"...'s password has expired..."` 异常，使 UC 与 LDAP 两条校验路径都能被 `ObjectBLL.Login` 的同一个关键字判断覆盖
- `Language/Resource_en-US.resx` / `Language/Resource_zh-CN.resx`：新增资源项 `USER_PWD_EXPIRED`
- 待确认项：UC 接口对"密码已过期"具体返回的 `message` 文案同样是按关键字猜测判断的（做法与本文件 2026.07.22 记录的"账号不存在"判断一致），建议上线前用一个真实密码已过期的账号测试一次，确认落入的是新的密码过期分支而不是被误判成"密码不正确"

---

# 2026.07.22 (2)

## 修复 DataImport 页面导入 AnimalInfo(update) 大文件时报 "Request timed out"

- `CrownbioHubase/HuData/importDB.ashx.cs`：`UpdateAnimalInfo` 方法开头新增 `context.Server.ScriptTimeout = 1800`（30分钟）
- 原因：该方法对 Excel 每一行动物记录都要逐行查库/更新（`ANIMAL_INFO`/`ANIMAL_INFO_LOGS`/`DROPDOWNLIST`/`PROJECT_BOOKING`/`SYS_USER` 等，无批量查询），维持数据文件行数达 9000+ 时累计耗时超过 ASP.NET 默认 110 秒请求超时，导致 `HttpException: Request timed out`；本次仅延长超时时间兜底，未改动导入逐行处理逻辑，大文件导入仍会耗时数分钟
- 待优化项：如后续文件量继续增长导致导入耗时过长，需考虑将逐行多次查询改为批量查询后内存匹配、批量提交更新，以从根本上提速

---

# 2026.07.22

## 登录验证方式由本地 LDAP 改为调用用户中心(UC) API，LDAP 降级为兜底

- `Utility/SecureHelper.cs`（新增）：`GetSHA1`/`GetMD5` 不可逆哈希；`EncPwd` 生成传给 UC 接口的 `po` 参数（一次性随机 DES key 加密明文密码 + 用共享密钥计算的校验片段，供 UC 后端解密还原明文密码去做 AD 绑定）。同步在 `Utility/Utility.csproj` 里加 `Compile Include`
- `BLLRemote/Rule/ActiveDirectoryConnector.cs`
  - `IsUserLoggedIn` 改为先调用 `AuthenticateAgainstUc`（GET `{UcApiUrl}/syswebapi/sysuserapi/login?u=..&p=SHA1(明文密码)小写&po=..&sid=..&lang=en`），响应不含 `"message":` 字段视为通过（忽略返回的 token，登录态仍走本地 Session 机制，未做改动）；命中 `not exist`/`not found` 关键字判定为 `ActiveDirectoryUserNotFoundException`（账号不存在），其余 message 判定为密码错误等直接抛 `Exception`——这两种情形与调用方 `ObjectBLL.Login()` 原有的异常语义保持一致，`ObjectBLL.cs` 未做任何改动
  - 新增 `UcUnavailableException`（私有），仅在 UC 接口打不通（`UcApiUrl` 未配置、网络异常、超时、空响应）时触发，捕获后自动回退到原 `AuthenticateAgainstDomain` 多域校验逻辑（原 `IsUserLoggedIn` 方法体原样保留，改名为私有 `IsUserLoggedInViaLdap`）
  - 原有的 `GetDepartmentByUser`/`GetEmailByUser`/`GetGroupByUser` 等辅助方法未改动，仍走本地 LDAP，不受此次改造影响
- `CrownbioHubase/Web.config`（未纳入版本控制，需手动同步到部署环境）：`appSettings` 新增 `UcApiUrl`（`http://uc.crownbio.com`）与 `UcApiKey`（UC 提供的接入共享密钥）
- 待确认项：UC 接口对"账号不存在"类失败具体返回的 `message` 文案目前是按 `not exist`/`not found` 关键字猜测判断的，建议上线前用一个真实不存在的账号测试一次，确认落入的是"用户不存在"分支而不是被误判成"密码错误"

---

# 2026.07.17

## AD 登录支持新旧双域验证，修复"密码错误"被误判为"用户不存在"

- `BLLRemote/Rule/ActiveDirectoryConnector.cs`
  - 新增 `ActiveDirectorySettingsCn` 读取独立的 `ldapConfigurationCn` 配置节（对应新域 `crownbio.cn`），与原 `ActiveDirectorySettings`（`ldapConfiguration`，旧域 `crownbio.com`）并存
  - `IsUserLoggedIn` 抽出私有方法 `AuthenticateAgainstDomain`，改为依次尝试新域→旧域，任一域验证通过即返回 `true`；未配置 `ldapConfigurationCn` 时该域自动跳过，单域行为与改造前一致
  - 新增 `ActiveDirectoryUserNotFoundException`，用于区分"账号在该域里确实不存在"与"密码错误/账号锁定/账号过期"等其他失败原因；`DirectoryServicesCOMException` 分支改为解析 AD 扩展错误码（`data 52e`=密码错误、`data 525`=账号不存在、`data 532/533/701/775`=密码过期/禁用/过期/锁定），不再统一 `return false`
  - 多域尝试时优先保留信息量更高的失败原因（如密码错误），"账号不存在"优先级最低，避免被更具体的错误覆盖
- `BLLRemote/System/ObjectBLL.cs`：`Login()` 捕获 `IsUserLoggedIn` 抛出的异常，`ActiveDirectoryUserNotFoundException` 维持原有"用户不存在"提示，其余异常（密码错误等）直接提示密码不正确，不再误报"用户不存在"
- `CrownbioHubase/Web.config`（未纳入版本控制，需手动同步到部署环境）：`configSections` 新增 `ldapConfigurationCn` 节声明，并新增对应的 `<ldapConfigurationCn .../>` 节点（`server=172.30.0.1`，`domain=crownbio.cn`，`directoryPath=DC=crownbio,DC=cn`）

---

# 2026.06.23 (4)

## 修复 Person.ashx.cs SQL 注入（C1 第三批）

全文 76+ 处 USER_INPUT `.Clause` 字符串拼接改为参数化查询，主要涉及：

- `SaveUserColumns`：`userLogin.USER_ID` / `Table` → `@scUserId` / `@scTable`
- `deleteMuPrime`：`delMuPrime_ID` → `@delMuPrimeId`
- `CancelWithDraw` / `ConfirmWithDraw` / `GotoWithDraw`：动态 IN 参数 `@twId1_N` / `@twId2_N` / `@ssIdN`
- `btnSaveLocation` / `SetMaps_location` / `edit_Locations` / `Remove_ModelTree_Node` / `delete_ModelTree_Node` / `Remove_Locations` / `delete_location` / `SaveLocations_Name` / `edit_locationName` / `CopyLocations` / `copyChild_location`
- `SavePharmacology_Effect`：`hfTreeID` / `hfEffectID` → `@pharmTreeId` / `@pharmEffectId`
- `getTableDisplayColumns`：`Table` → `@tblName`
- `MoveToSubproject`：`hfSubProject` / `hfRequest_id` → `@subproj` / `@reqId`
- `MoveToStudyDesign`：`Monitor_id` / `cbxToProject` / 动态 IN `cbxToModelID` → `@monId` / `@cbxProj` / `@midN`；`Monitor_id` 第二处 → `@sdMonId`
- `SaveBooking`：`rid`、revival/animal/doi/monitor 分支、`FurtherExpanding` 等 20+ 个参数
- `SaveRequest`：`hfProjNum` / `hfRequest_id` → `@srProjNum` / `@srReqId`；动态 NOT IN `editModel_ID`
- `deleteStudy`：动态 IN `hfStudy_id` → `@dsIdN`
- `DeleteMonitor`：动态 IN `hfMonitor_id` → `@monIdN`
- `deleteNewModel`：`delNewModel_ID` → `@delNewModelId`
- `deleteSpecimenStocks`：动态 IN `delSpecimen_Stock_ID` → `@sstkIdN`
- `deleteValidation` / `deleteEndModels` / `deleteValidationStatus_Huprime` / `deleteRevival` / `deleteGeneticTest` / `deleteValidationStatus_Hukime` / `deleteRoutineMaintain` / `deleteRequest`：各自 ID 字段参数化
- `SaveAnimal_Handover`：`hfMid` / `hfRid` → `@ahMid` / `@ahRid`（ANIMAL_HANDOVER、子查询）
- `pl4`（PROJECT_MONITOR）：`hfMid` / `hfRid` → `@pl4Mid` / `@pl4Rid`
- `SavePiggybacked`：`hfMid` / `hfRid` → `@pbMid` / `@pbRid`
- `SavePM_Edit`：`hfRequest_id` → `@pmEditReqId`；后续 `hfRequest_id` → `@pl1ReqId`
- `Complete_study`：`hfMonitor_id` → `@csMonId`
- `SaveMonitorPM_edit`：`hfMonitor_id` → `@pmEditMonId`
- `SaveMonitorJSD_edit`：`hfMonitor_id` → `@jsdEditMonId`
- `SaveRoutineMaintain` / `SaveValidation` / `SaveNewModel` / `SaveEndModels` / `SaveRevival` / `SaveGeneticTest` / `SaveValidationStatus_Huprime` / `SaveValidationStatus_Hukime`：`decimal pid` → `@rmPid` / `@valPid` / `@nmPid` / `@emPid` / `@rvPid` / `@gtPid` / `@vshpPid` / `@vshkPid`（DbType.Decimal）
- `Save_SpecimenStocks`：`decimal pid` → `@ssPid`（DbType.Decimal）
- 导入方法：`lists[0]` → `@atMid1` / `@atMid2`；`lists[5]` → `@importProjNum`
- `Save_SpecimenStocks`：`aa` (animal_id) → `@aaAnimalId`
- `getDDLtxtSource`：`ddlname` → `@ddlName`

---

# 2026.06.23 (3)

## 修复 UserFunction.ashx.cs SQL 注入（C1 第二批）
- `SaveDropDownList`：`hfddlID` → `@ddlId`
- `DeleteUser`：`uid` (USER_ID) → `@userId`
- `DeleteRole`：`uid` (roleID) → `@roleId`
- `EditUser`：`uid` (User_ID) → `@editUserId`
- `ShowUser`：子查询中 `id` (USER_ID) → `@showUserId`（额外发现，来自 request）
- `ReturnPRO_SYS_USER`：子查询中 `user.USER_ID` → `@roleUserId`（一致性修复）

---

# 2026.06.23 (2)

## 修复登录接口 SQL 注入（C1 首批）
- `BLLRemote/System/ObjectBLL.cs`：`Login()` 和 `LoginSSO()` 中 6 处 `.Clause` 字符串拼接改为参数化查询
  - `email = '...'` → `email = @loginEmail` + `ParamData`
  - `USER_CODE = '...'` → `USER_CODE = @loginCode` + `ParamData`
  - `EMAIL = '...'`（AD 分支）→ `EMAIL = @adEmail` + `ParamData`

---

# 2026.06.23

## 更新替换中文逗号和分号
```
.DROPDOWNLIST_CONTEXT.Split(';')
→ .DROPDOWNLIST_CONTEXT.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries)

.DROPDOWNLIST_CONTEXT.Split(',')
→ .DROPDOWNLIST_CONTEXT.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)

nodes.Split(',')
→ nodes.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
```

## 邮件地址更新
- `SendEmail.cs`：所有外发邮件新增 BCC 至 `runjun.jia@crownbio.com`
- `Person.ashx.cs`：新 HuData Request 通知邮件收件人由 `lijun@crownbio.com` 改为 `runjun.jia@crownbio.com`
- `ToExport.cs`、`webAPItest.aspx`、`userLogin.ashx.cs`：测试邮件地址同步由 `lijun@crownbio.com` 改为 `runjun.jia@crownbio.com`
