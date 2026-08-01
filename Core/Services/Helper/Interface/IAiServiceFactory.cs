using Core.Model;

namespace Core.Services.Helper.Interface;

public interface IAiServiceFactory
{
    IAiService GetUserService(UserAiProvider provider);
}