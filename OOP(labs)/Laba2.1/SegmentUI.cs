using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2._1
{
    class SegmentUI
    {
        private Segment segmentUI;

        public SegmentUI()
        {
            segmentUI = new Segment();
        }

        public void OutputGetLengthSegment()
        {
            double lengthSegment = segmentUI.GetLengthSegment;
            Console.WriteLine(lengthSegment);
        }

        public void OutputMoveSegment()
        {
            int inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumber);

            while (!result)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            segmentUI.MoveSegment(inputNumber); 
            OutputDisplayCoordinatesOfSegment();
        }

        public void OutputCheckHitPointInSquare()
        {
            bool result = segmentUI.CheckHitPointsInSquare();
            Console.WriteLine(result);
        }

        public void OutputDisplayCoordinatesOfSegment()
        {
            Console.Write(segmentUI.X1);
            Console.Write(" ");
            Console.Write(segmentUI.Y1);
            Console.Write(" ");
            Console.Write(segmentUI.X2);
            Console.Write(" ");
            Console.WriteLine(segmentUI.Y2);
        }

    }
}
