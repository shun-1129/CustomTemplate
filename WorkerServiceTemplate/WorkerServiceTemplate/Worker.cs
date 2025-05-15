using Microsoft.Extensions.Options;
using TestSolution.WorkerServiceTemplate.Logics;
using TestSolution.WorkerServiceTemplate.Models.Data;

namespace TestSolution.WorkerServiceTemplate
{
    public class Worker : BackgroundService
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<Worker> _logger;
        /// <summary>
        /// アプリケーション設定
        /// </summary>
        private readonly Appsettings _appsettings;
        /// <summary>
        /// スレッドリスト
        /// </summary>
        private List<Task> _threadList = new List<Task> ();

        private List<ControllableTransferRobotData> _controllableTransferRobotDataList = new List<ControllableTransferRobotData> ();

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="logger">ロガー</param>
        /// <param name="appsettings">モジュール設定</param>
        public Worker ( ILogger<Worker> logger , IOptions<Appsettings> appsettings )
        {
            _logger = logger;
            _appsettings = appsettings.Value;
        }

        /// <summary>
        /// 非同期実行
        /// </summary>
        /// <param name="stoppingToken">停止トークン</param>
        protected override async Task ExecuteAsync ( CancellationToken stoppingToken )
        {
            GenerateThread ( stoppingToken , 5 );
            ServiceExecutor serviceExecutor = new ServiceExecutor ( _appsettings );

            while ( !stoppingToken.IsCancellationRequested )
            {
                // 別に要らないログ
                if ( _logger.IsEnabled ( LogLevel.Information ) )
                {
                    //_logger.LogInformation ( "Worker running at: {time}" , DateTimeOffset.Now );
                }

                //await serviceExecutor.Executor ();

                await Task.Delay( _appsettings.DelayTimeMs , stoppingToken );
            }
        }

        /// <summary>
        /// スレッド生成
        /// </summary>
        /// <param name="cancellationToken">停止トークン</param>
        /// <param name="threadCount">スレッド数</param>
        private void GenerateThread ( CancellationToken cancellationToken , int threadCount = 1 )
        {
            ControlVehicles controlVehicles = new ControlVehicles ( _appsettings );

            for ( int i = 0 ; i < threadCount ; i++ )
            {
                int threadId = i + 1;
                _threadList.Add ( Task.Run ( () => controlVehicles.ExecutorAsync ( threadId , cancellationToken ) ) );
            }
        }
    }
}
