using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;


namespace BlazorExpenseTracker.Services.Auth
{
    public class ExpTrackerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage;
        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        const string USER_SESSION_KEY = "UserSession";

        public ExpTrackerAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage)
        {
            _protectedSessionStorage = protectedSessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var sessionStorageResult = await _protectedSessionStorage.GetAsync<ExpTrackerUserSession>(USER_SESSION_KEY);
                var expTrackerUserSession = sessionStorageResult.Success ? sessionStorageResult.Value : null;

                if (expTrackerUserSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, expTrackerUserSession.Username),
                    new Claim(ClaimTypes.Role, expTrackerUserSession.Role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(ExpTrackerUserSession? expTrackerUserSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (expTrackerUserSession != null)
            {
                await _protectedSessionStorage.SetAsync(USER_SESSION_KEY, expTrackerUserSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, expTrackerUserSession.Username),
                    new Claim(ClaimTypes.Role, expTrackerUserSession.Role)
                }));
            }
            else
            {
                await _protectedSessionStorage.DeleteAsync(USER_SESSION_KEY);
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

    }
}
