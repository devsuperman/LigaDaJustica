using Microsoft.AspNetCore.Mvc;

namespace LigaDaJustica.Extensions
{
    public static class ControllerExtensions
    {
        public static void NotificarSucesso(this Controller controller, string mensagem = "Operação concluída com sucesso.")
        {   
            controller.TempData["alerta"] = mensagem;
        }            
    }
}