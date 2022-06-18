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
        };

        const int ADD = 16;
        const int SET = 64;
        const int JMP = 66;
        const int IP = 5;

        public static short[] register = new short[6];
        public static int[] instructions = new int[6];

        public static int loop = 5;
        static void PrintRegister()
        {
            for (int i = 0; i < register.Length; i++)
            {
                Console.WriteLine(register[i]);
            }
            Console.WriteLine();
        }
        static bool IsPowerOfTwo(int number)
        {
            if (number >> 1 == 1)
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

        static void DoWork()
        {
            int cI = register[IP];

            byte OpCode = GetNthByte(instructions[cI], 3);
            byte b1 = GetNthByte(instructions[cI], 2);
            byte b2 = GetNthByte(instructions[cI], 1);
            byte b3 = GetNthByte(instructions[cI], 0);

            if (OpCode == 0x40) //SET
            {
                register[b1] = b3;
                register[IP]++;
            }
            else if (OpCode == 0x10) //ADD
            {
                register[b3] = (short)(register[b1] + register[b2]);
                register[IP]++;
            }
            else if (OpCode == 0x42) //JMP
            {
                register[IP] = b1;
            }
            else if (OpCode == 0x31) //JMPT
            {
                if (b1 <= b3)
                {
                    //JMP
                    
                    register[IP] = 31;
                }
                else
                {
                    //cont
                    register[IP]++;
                }
            }
        }

        static void Main()
        {
            instructions[0] = 0x4000FF01; //SET
            instructions[1] = 0x4001FF01; //SET
            instructions[2] = 0x4002FF05; //SET

            instructions[3] = 0x10000100; //ADD
            //instructions[4] = 0x4202FFFF; //JMP

            //JMPT
            while (true)
            {
                DoWork();
                instructions[5] = 0x31000203; //JMPT
                PrintRegister();
            }

        }



        /// <summary>
        /// Instructions
        /// </summary>
        /// Math 0x10 (ADD, SUB, MUL, DIV, MOD, SHL, SHR)
        /// Logic 0x20 (AND, OR, XOR, NOT, GTE, LTE, GT, LT, EQ)
        /// Flow Control 0x30 (JMP, JMPT (maybe JMPZ))
        /// Memory 0x40 (SET, COPY (MOV), LOAD, STORE, PUSH, POP)
        /// Category, ASM, OpCode, Layout (OpCode, posA, posB, posC), Description, Example (english input and hex example)

    }
}