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
