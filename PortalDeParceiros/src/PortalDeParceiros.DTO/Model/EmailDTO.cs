using System.Text;

namespace PortalDeParceiros.Dto.Model
{
    public class EmailDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LinkSite => "http://10.2.0.138";
        public string MessageCreat{ get {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"Olá {Name}, <br/><br/>");
            sb.Append("Seu acesso ao portal esta disponível pelo link ");
            sb.Append($"<a href='{LinkSite}'>Portal de parceiros</a> <br/><br/>");
            sb.Append($"Usuário: {Email}<br />");
            sb.Append($"Senha: {Password}<br /><br />");
            sb.Append($"Att. Novi");

            return sb.ToString();
        }}

        public string MessageReset{ get {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"Olá {Name}, <br/><br/>");
            sb.Append("Seu acesso ao portal foi redefinido e esta disponível pelo link ");
            sb.Append($"<a href='{LinkSite}'>Portal de parceiros</a> <br/><br/>");
            sb.Append($"Usuário: {Email}<br />");
            sb.Append($"Senha: {Password}<br /><br />");
            sb.Append($"Att. Novi");

            return sb.ToString();
        }}
    }
}