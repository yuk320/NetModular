using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nm.Lib.Utils.Core.Result;
using Nm.Module.PersonnelFiles.Application.UserService;
using Nm.Module.PersonnelFiles.Application.UserService.ViewModels;
using Nm.Module.PersonnelFiles.Domain.User.Models;

namespace Nm.Module.PersonnelFiles.Web.Controllers
{
    [Description("用户信息管理")]
    public class UserController : ModuleController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery] UserQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(UserAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public async Task<IResultModel> Delete([BindRequired] Guid id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public async Task<IResultModel> Edit([BindRequired] Guid id)
        {
            return await _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(UserUpdateModel model)
        {
            return _service.Update(model);
        }
    }
}
