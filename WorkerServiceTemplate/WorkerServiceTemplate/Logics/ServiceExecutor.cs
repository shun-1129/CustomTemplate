using CommonLibrary.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestSolution.WorkerServiceTemplate.Models.Data;

namespace TestSolution.WorkerServiceTemplate.Logics
{
    public class ServiceExecutor
    {
        private Logger _logger;
        private Appsettings _appsettings;

        public ServiceExecutor ( Appsettings appsettings )
        {
            _logger = new Logger ( typeof ( ServiceExecutor ) );
            _appsettings = appsettings;
        }

        public async Task Executor ( List<ControllableTransferRobotData> controllableTransferRobotDataList )
        {
            List<TMovementInterlockArea> movementInterlockAreaList = await GetData ();

            List<ControllableTransferRobotData> temp = movementInterlockAreaList
                .GroupBy ( x => x.MovementId )
                .Select ( x => new ControllableTransferRobotData ()
                {
                    MovementId = x.Key,
                    TransferRobotId = x.First ().TransferRobotId,
                    MovementInterlockArea = x.ToList ()
                })
                .ToList ();

            List<ControllableTransferRobotData> data = new ();
        }

        private async Task<List<TMovementInterlockArea>> GetData ()
        {
            List<TMovementInterlockArea> movementInterlockAreaList = new List<TMovementInterlockArea> ();

            for ( int id = 1 ; id <= 10 ; id++ )
            {
                for ( int data = 0 ; data < 20 ; data++ )
                {
                    if ( data % 2 != 0 )
                    {
                        continue;
                    }

                    TMovementInterlockArea movementInterlockArea = new TMovementInterlockArea ()
                    {
                        TransferRobotId = id,
                        MovementId = id,
                        AddressNo = data,
                        IsJudge = true,
                        IsEntry = false,
                        IsReserved = false,
                        IsPassed = false,
                    };

                    movementInterlockAreaList.Add ( movementInterlockArea );
                }
            }

            await Task.Delay ( 10 );
            return movementInterlockAreaList;
        }
    }
}
