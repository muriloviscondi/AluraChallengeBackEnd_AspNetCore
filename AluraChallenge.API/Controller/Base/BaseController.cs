using AluraChallenge.Domain.Interfaces.Services.Base;
using AluraChallenge.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraChallenge.API.Controller.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private IServiceBase _serviceBase;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [NonAction]
        protected IActionResult ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (!_serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();

                    if (result == null)
                    {
                        return Ok();
                    }

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    // Aqui devo logar o erro
                    return Conflict($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = serviceBase.Notifications });
            }
        }

        protected IActionResult ModelStateErros()
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                );

            var notifications = new List<Notification>();

            foreach (var error in errors)
            {
                notifications.Add(new Notification(error.Key, error.Value));
            }

            return BadRequest(new { errors = notifications });
        }
    }
}
