// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Reliability", "CA2007:Попробуйте вызвать ConfigureAwait для ожидаемой задачи", Justification = "<Ожидание>", Scope = "member", Target = "~M:WebApplication1.Controllers.RecordsController.Index(System.DateTime,System.String)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Design", "CA1054:Параметры, напоминающие URI, не должны быть строками", Justification = "<Ожидание>", Scope = "member", Target = "~M:WebApplication1.Controllers.LoginController.Validate(System.String,System.String,System.Boolean,System.String)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
