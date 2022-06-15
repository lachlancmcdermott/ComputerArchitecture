using System;

namespace BinaryConversion
{
    class Program
    {
        enum OpCodes : byte
        {
            ADD = 0x10,
            SET = 0x40,
            JMP = 0x42
        }

        short[] register = new short[5];

        static bool IsPowerOfTwo(int number)
        {
            if (number >>1 == 1)
            {
                return true;
            }
            return false;
        }
        static int ClosestPowerOfTwo(int number)
        {
            int n = 0;
            while (true)
            {
                if (Math.Pow(2, n) > number)
                {
                    n--;
                    return n;
                }
                n++;
            }
        }
        static int LoopWithoutLoop(int number)
        {
            start:
            if (number > 0)
            {
                goto end;
            }
            else
            {
                number--;
                goto start;
            }
            end:
            return number;
        }

        static bool IsNthBitOne(int number, int bitIndex)
        {
            int mask = 1 << bitIndex;
            return (mask & number) == mask;
        }
        static byte GetNthByte(int number, int i)
        {
            number = number >> (i * 8);
            return (byte)(number & 0b_1111_1111);
        }


        static void DoWork(int instruction, short[] register)
        {
            byte OpCode = GetNthByte(instruction, 3);
            byte b1 = GetNthByte(instruction, 2);
            byte b2 = GetNthByte(instruction, 1);
            byte b3 = GetNthByte(instruction, 0);
            if (OpCode == 64) //SET 0x40
            {
                //0x40_10-
                //you have a register value (index) and a value that you are setting into the register
                register[0] = b3;
            }
            else if(OpCode == 16) //ADD 0x10
            {
                register[0] = register[]
            }
            else if(OpCode == 66) //JMP 0x42
            {

            }
        }


        static void Main(string[] args)
        {
            short[] register = new short[5];
            DoWork(0x40001000, register);
        }
    }
}
