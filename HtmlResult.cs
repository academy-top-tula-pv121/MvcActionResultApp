using Microsoft.AspNetCore.Mvc;

namespace MvcActionResultApp
{
    public class HtmlResult : IActionResult
    {
        string html;
        public HtmlResult(string html)
        {
            this.html = html;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            string htmlPage = @$"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Html Page</title>
</head>
<body>
    {html}
</body>
</html>";
            await context.HttpContext.Response.WriteAsync(htmlPage);
        }
    }
}
