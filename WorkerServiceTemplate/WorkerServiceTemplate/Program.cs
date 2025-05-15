using NLog.Web;
using TestSolution.WorkerServiceTemplate.Models.Data;

namespace TestSolution.WorkerServiceTemplate
{
    public class Program
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// メイン
        /// </summary>
        /// <param name="args"></param>
        public static void Main ( string[] args )
        {
            _logger.Info ( "Initial Main" );
            IHost host = CreateHost ( args );
            host.Run ();
        }

        /// <summary>
        /// ホスト作成
        /// </summary>
        /// <remarks>
        /// 1. ホスト作成<br/>
        /// 2. appsettings.jsonの読み取り
        /// </remarks>
        /// <param name="args">Mainメソッドの引数</param>
        /// <returns>ホスト</returns>
        private static IHost CreateHost ( string[] args ) => Host.CreateDefaultBuilder ( args )
            .ConfigureLogging ( logging =>
            {
                logging.ClearProviders ();
                logging.SetMinimumLevel ( LogLevel.Trace );
            } )
            .UseNLog ()
            .ConfigureServices ( ( hostContext , services ) =>
            {
                services.Configure<Appsettings> ( hostContext.Configuration.GetSection ( "AppSettings" ) );
                services.AddHostedService<Worker> ();
            } )
            .Build ();
    }
}