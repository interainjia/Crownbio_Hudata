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
