using NLog;
using TestSolution.WorkerServiceTemplate.Models.Data;

namespace TestSolution.WorkerServiceTemplate.Logics
{
    public class ControlVehicles
    {
        private CommonLibrary.Common.Logger _logger;
        private Appsettings _appsettings;

        public ControlVehicles ( Appsettings appsettings )
        {
            _logger = new CommonLibrary.Common.Logger ( LogManager.GetCurrentClassLogger () );
            _appsettings = appsettings;
        }

        public async Task ExecutorAsync ( int threadId , CancellationToken cancellationToken )
        {
            using ( ScopeContext.PushProperty ( "ThreadId" , $"{threadId}" ) )
            {
                int count = 1;
                while ( !cancellationToken.IsCancellationRequested )
                {
                    await Task.Delay ( _appsettings.DelayTimeMs );

                    _logger.Info ( $"{count}回目" );
                    _logger.Debug ( $"ThreadID:{threadId} , {count}回目" );
                    count++;
                }
            }
        }
    }
}
