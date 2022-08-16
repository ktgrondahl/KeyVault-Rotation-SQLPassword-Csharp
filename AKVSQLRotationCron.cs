using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;



namespace Microsoft.KeyVault
{
    public static class AKVSQLRotationCron
    {
        [FunctionName("AKVSQLRotationCron")]
        public static void Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            string keyVaultName;
            string secretName;


            keyVaultName = Environment.GetEnvironmentVariable("keyVaultName");
            secretName = Environment.GetEnvironmentVariable("secretName");

            log.LogInformation("Starting Secret Rotator Function");

            SecretRotator.RotateSecret(log,secretName ,keyVaultName);

            return new OkObjectResult($"Secret Rotated Successfully");
        }
    }
}
