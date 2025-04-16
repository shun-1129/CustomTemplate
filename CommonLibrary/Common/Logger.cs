namespace CommonLibrary.Common
{
    /// <summary>
    /// ロガークラス
    /// </summary>
    public class Logger
    {
        private NLog.Logger _logger;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="type"></param>
        public Logger ( Type type )
        {
            _logger = NLog.LogManager.GetLogger ( type.FullName );
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logger"></param>
        public Logger ( NLog.Logger logger )
        {
            _logger = logger;
        }

        /// <summary>
        /// ログ書き込み
        /// </summary>
        /// <param name="level">ログレベル</param>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        private void Write ( NLog.LogLevel level , string message , params object[] args )
        {
            if ( _logger != null )
            {
                _logger.Log ( level, message, args );
            }
        }

        /// <summary>
        /// Infoレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Info ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Info, message, args );
        }

        /// <summary>
        /// Debugレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Debug ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Debug, message, args );
        }

        /// <summary>
        /// Warnレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Warn ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Warn , message , args );
        }

        /// <summary>
        /// Errorレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Error ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Error, message, args );
        }

        /// <summary>
        /// Traceレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Trace ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Trace , message , args );
        }

        /// <summary>
        /// Fatalレベルログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="args">パラメータ</param>
        public void Fatal ( string message , params object[] args )
        {
            Write ( NLog.LogLevel.Fatal , message , args );
        }
    }
}
