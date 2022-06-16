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
            int b1 = GetNthByte(instruction, 2);
            int b2 = GetNthByte(instruction, 1);
            byte b3 = GetNthByte(instruction, 0);
            if (OpCode == 64) //SET - 0x40_Register#_FF_Value to store in register
            {
                register[b1] = b3;
            }
            else if(OpCode == 16) //ADD - 0x10_Register to add, register to add, first register (aka. sum)
            {
                register[b1] = register[b1] + register[b2];
            }
            else if(OpCode == 66) //JMP - 0x42 
            {
                //????
            }
        }


        static void Main(string[] args)
        {
            short[] register = new short[5];
            PrintRegister(register);
            Console.WriteLine();
            DoWork(0x4001FF01, register);
            PrintRegister(register);
        }
        
        static void PrintRegister(short[] register)
        {
            for (int i = 0; i < register.Length; i++)
            {
                Console.WriteLine(register[i]);
            }
        }

    }
}
