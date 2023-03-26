using AccountingApp.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace AccountingApp.API.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string Jwt = nameof(Jwt);
        IConfiguration configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            configuration.GetSection(Jwt).Bind(options);
        }
    }
}
