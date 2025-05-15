namespace TestSolution.WorkerServiceTemplate.Models.Data
{
    public class TMovementInterlockArea
    {
        public int TransferRobotId { get; set; }
        
        public long MovementId { get; set; }

        public int AddressNo { get; set; }

        public bool IsJudge { get; set; }

        public bool IsEntry { get; set; }

        public bool IsReserved { get; set; }

        public bool IsPassed { get; set; }
    }
}
