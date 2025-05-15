namespace TestSolution.WorkerServiceTemplate.Models.Data
{
    public class ControllableTransferRobotData
    {
        /// <summary>
        /// 移動指示ID
        /// </summary>
        public long MovementId { get; set; }

        /// <summary>
        /// 搬送ロボットマスタID
        /// </summary>
        public int TransferRobotId { get; set; }

        /// <summary>
        /// 移動指示インターロックエリアリスト
        /// </summary>
        public List<TMovementInterlockArea> MovementInterlockArea { get; set; } = new List<TMovementInterlockArea> ();

        /// <summary>
        /// 現在エリアID
        /// </summary>
        public int? CurrentAreaId { get; set; }

        /// <summary>
        /// 次エリアID
        /// </summary>
        public int? NextAreaId { get; set; }

        /// <summary>
        /// 停止要因エリアID
        /// </summary>
        public int? StopAreaId { get; set; }
    }
}
