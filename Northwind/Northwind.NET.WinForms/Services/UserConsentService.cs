using System;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Security.Credentials.UI;

namespace Northwind.NET.Services
{
    public class UserConsentService
    {
        private UserConsentService() { }

        private static UserConsentService current;

        public static UserConsentService Current => current ?? (current = new UserConsentService());

        public async Task<bool> ConfirmUserConsent()
        { 

            if (ApiInformation.IsTypePresent("Windows.Security.Credentials.UI.UserConsentVerifier"))
            {
                var ucvAvailability = await UserConsentVerifier.CheckAvailabilityAsync();

                if (ucvAvailability == UserConsentVerifierAvailability.Available)
                {
                    var ucvResult = await UserConsentVerifier.RequestVerificationAsync($"You are about to enter edit mode. Are you sure?");

                    return ucvResult == UserConsentVerificationResult.Verified;
                }
            }
            else
            {
                return true;
            }

            return true;
        }
    }
}
