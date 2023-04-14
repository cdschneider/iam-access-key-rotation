using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AccessKeyActions.Configuration;

public class FunctionConfiguration : IFunctionConfiguration
{
    private readonly IConfiguration _configuration;
    
    private static readonly string KeyRotationConfigurationKey = "Function:KeyRotation";
    private static readonly string KeyInstallationConfigurationKey = "Function:KeyInstallation";
    private static readonly string KeyRecoveryConfigurationKey = "Function:KeyRecovery";
    
    public FunctionConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TimeSpan AccessKeyRotationWindow()
    {
        var keyRotationSeconds = _configuration.GetValue<long?>(KeyRotationConfigurationKey);
        if (keyRotationSeconds == null)
        {
            return TimeSpan.FromDays(30);   
        }
        
        return TimeSpan.FromSeconds(Convert.ToDouble(keyRotationSeconds));
    }

    public TimeSpan AccessKeyInstallationWindow()
    {
        var keyInstallationSeconds = _configuration.GetValue<long?>(KeyInstallationConfigurationKey);
        if (keyInstallationSeconds == null)
        {
            return TimeSpan.FromDays(7);   
        }
        
        return TimeSpan.FromSeconds(Convert.ToDouble(keyInstallationSeconds));
    }

    public TimeSpan AccessKeyRecoveryWindow()
    {
        var keyRecoverySeconds = _configuration.GetValue<long?>(KeyRecoveryConfigurationKey);
        if (keyRecoverySeconds == null)
        {
            return TimeSpan.FromDays(7);   
        }
        
        return TimeSpan.FromSeconds(Convert.ToDouble(keyRecoverySeconds));
    }
}