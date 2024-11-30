using Microsoft.Extensions.Localization;
using System.Text;

namespace Allup.Application.Services.Implementations;

public class StringLocalizerService
{
    private readonly IStringLocalizer _stringLocalizer;

    public StringLocalizerService(IStringLocalizerFactory stringLocalizerFactory)
    {
        _stringLocalizer = stringLocalizerFactory.Create("SharedResources", "Allup.MVC");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
