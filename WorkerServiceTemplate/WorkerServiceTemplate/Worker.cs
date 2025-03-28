using Microsoft.Extensions.Options;
using WorkerServiceTemplate.Models.Data;

namespace WorkerServiceTemplate
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Appsettings _appsettings;

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
            while ( !stoppingToken.IsCancellationRequested )
            {
                // 別に要らないログ
                if ( _logger.IsEnabled ( LogLevel.Information ) )
                {
                    _logger.LogInformation ( "Worker running at: {time}" , DateTimeOffset.Now );
                }

                /* ここから処理を入れてください。 */
                /* ここまで処理を入れてください。 */

                await Task.Delay( _appsettings.DelayTimeMs , stoppingToken );
            }
        }
    }
}
