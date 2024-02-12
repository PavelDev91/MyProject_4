/*
 * Pavel Dev
 * GitHub: PavelDev91
 * E-mail: PavelDev1991@gmail.com
 */

using System;
using System.Globalization;

namespace _MyFunc
{
    public static class MyFunc
    {
        //-----------------------------------------------------
        public static void IntArray_Sort(ref int[] IntArray, bool Reverse = false)
        {
            bool ws = false;

            while (true)
            {
                int value;

                for (int i = 0; i < IntArray.Length; i++)
                {
                    if (i + 1 == IntArray.Length)
                    {
                        break;
                    }

                    if (IntArray[i + 1] >= IntArray[i])
                    {
                        continue;
                    }
                    else
                    {
                        value = IntArray[i + 1];

                        IntArray[i + 1] = IntArray[i];
                        IntArray[i] = value;
                    }
                }

                for (int i = 0; i < IntArray.Length; i++)
                {
                    if (i + 1 == IntArray.Length)
                    {
                        break;
                    }

                    ws = false;

                    if (IntArray[i] <= IntArray[i + 1])
                    {
                        ws = true;
                    }

                    if (ws == false)
                    {
                        break;
                    }
                }

                if (ws == true)
                {
                    if (Reverse == true)
                    {
                        for (int i = 0; i <= IntArray.Length / 2; i++)
                        {
                            value = IntArray[(IntArray.Length - 1) - i];

                            IntArray[(IntArray.Length - 1) - i] = IntArray[i];
                            IntArray[i] = value;
                        }
                    }

                    return;
                }
            }
        }
        //-----------------------------------------------------
        public static int IntNot(int Value)
        {
            int res = 0;

            int[] vArray = new int[32];

            int xv = 0;

            if (Value < 0)
            {
                Value = -1 - Value;

                vArray[vArray.Length - 1] = 0;
            }
            else
            {
                vArray[vArray.Length - 1] = 1;
            }

            for (int i = 0; i < vArray.Length - 1; i++)
            {
                vArray[i] = 0;
            }

            xv = 0;

            for (int i = 0; i < vArray.Length-1; i++)
            {
                if (Value >= IntToExp(2, (vArray.Length - 2) - i) + xv)
                {
                    xv += IntToExp(2, (vArray.Length - 2) - i);

                    vArray[i] = 1;
                }
            }

            for (int i = vArray.Length - 1; i >= 0; i--)
            {
                if (vArray[i] == 1)
                {
                    res += IntToExp(2, (vArray.Length - 2) - i);
                }
            }

            if (vArray[vArray.Length - 1] == 1)
            {
                res = 0 - res;
            }

            return res;
        }
        //-----------------------------------------------------
        public static bool String_DecimalOrNotDecimal(string Value)
        {
            bool res = false;

            if (Value.Length == 0)
            {
                return res;
            }

            if (Value.Length > 1 && Value[0] == '-')
            {
                Value = Value.Substring(1, Value.Length - 1);
            }

            if (Value.Length > 1 && Value[0] == '.')
            {
                return res;
            }

            if (Value.Length > 1 && Value[Value.Length - 1] == '.')
            {
                return res;
            }

            int dot = -1;

            for (int i = 0; i < Value.Length; i++)
            {
                if (Value[i] != '.')
                {
                    continue;
                }

                if (Value[i] == '.' && dot == -1)
                {
                    dot = i;

                    continue;
                }

                return res;
            }

            for (int i = 0; i < Value.Length; i++)
            {
                if (i == dot)
                {
                    continue;
                }

                res = false;

                switch (Value[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        res = true;
                        break;
                }

                if (res == false)
                {
                    return res;
                }
            }

            return res;
        }
        //-----------------------------------------------------
        public static bool String_IntOrNotInt(string Value)
        {
            bool res = false;

            if (Value.Length == 0)
            {
                return false;
            }

            if (Value.Length > 1 && Value[0] == '-')
            {
                Value = Value.Substring(1, Value.Length - 1);
            }

            for (int i = 0; i < Value.Length; i++)
            {
                res = false;

                switch (Value[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        res = true;
                        break;
                }

                if (res == false)
                {
                    return res;
                }
            }

            return res;
        }
        //-----------------------------------------------------
        public static int IntToExp(int Value, int Exp)
        {
            int res = 1;

            for (int i = 0; i < Exp; i++)
            {
                res *= Value;
            }

            return res;
        }
        //-----------------------------------------------------
        public static decimal DecimalToExp(decimal Value, decimal Exp)
        {
            decimal res = 1;

            for (int i = 0; i < Exp; i++)
            {
                res *= Value;
            }

            return res;
        }
        //-----------------------------------------------------
        public static int? StringToInt(string Value)
        {
            int? res = 0;

            if (String_IntOrNotInt(Value) == false)
            {
                return null;
            }

            bool pref = false;

            if (Value[0] == '-')
            {
                pref = true;

                Value = Value.Substring(1, Value.Length - 1);
            }

            int x;

            for (int i = 0; i < Value.Length; i++)
            {
                switch (Value[i])
                {
                    case '0':
                        x = 0;
                        break;

                    case '1':
                        x = 1;
                        break;

                    case '2':
                        x = 2;
                        break;

                    case '3':
                        x = 3;
                        break;

                    case '4':
                        x = 4;
                        break;

                    case '5':
                        x = 5;
                        break;

                    case '6':
                        x = 6;
                        break;

                    case '7':
                        x = 7;
                        break;

                    case '8':
                        x = 8;
                        break;

                    case '9':
                        x = 9;
                        break;

                    default:
                        x = 0;
                        break;
                }

                res += x * (IntToExp(10, (Value.Length - 1) - i));
            }

            if (pref == true)
            {
                res = 0 - res;
            }

            return res;
        }
        //-----------------------------------------------------
        public static double IntToSqrt(double Value)
        {
            if (Value <= 0)
            {
                return 0;
            }
            //-------------------------------------------------
            double res;

            double x;
            //-------------------------------------------------
            x = 1d;

            double z = 0d;

            res = Value;

            while (x <= res)
            {
                res -= x;
                x += 2;

                z++;
            }

            x = z;
            res = (double)(Value / x);
            res = (double)(x + res);
            res = (double)(res / 2d);

            x = (double)(res);
            res = (double)(Value / x);
            res = (double)(x + res);
            res = (double)(res / 2d);

            x = (double)(res);
            res = (double)(Value / x);
            res = (double)(x + res);
            res = (double)(res / 2d);

            x = (double)(res);
            res = (double)(Value / x);
            res = (double)(x + res);
            res = (double)(res / 2d);

            return res;
        }
        //-----------------------------------------------------
        public static decimal? StringToDecimal(string Value)
        {
            decimal? res = null;

            if (String_DecimalOrNotDecimal(Value) == false)
            {
                return res;
            }

            int? dot = null;

            string buff = "";

            for (int i = 0; i < Value.Length; i++)
            {
                if (Value[i] == '.')
                {
                    dot = i;

                    break;
                }

                buff += Value[i];
            }

            if (dot != null)
            {
                Value = Value.Substring((int)(dot + 1), (int)(Value.Length - (dot + 1)));
            }
            //-------------------------------------------------
            if (dot == null)
            {
                return (decimal)(StringToInt(Value));
            }
            //-------------------------------------------------
            res = (decimal)(StringToDecimal(buff));

            decimal v;

            res = 0.0m;
            Value = "012345678090";
            //-------------------------------------------------
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value[i] == '0')
                {
                    v = 0.0m;
                }
                else
                {
                    v = 0.1m;
                }

                if (i == 0)
                {
                    res += DecimalToExp(v, i + 1);
                }
                else
                {
                    res += DecimalToExp(v, i+1);
                }

                for (int x = 0; x < StringToInt(Value[i].ToString()); x++)
                {
                    res += DecimalToExp(v, i);
                }

                continue;

                if (i == 0)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0m;
                            break;

                        case '1':
                            res += 0.1m;
                            break;

                        case '2':
                            res += 0.2m;
                            break;

                        case '3':
                            res += 0.3m;
                            break;

                        case '4':
                            res += 0.4m;
                            break;

                        case '5':
                            res += 0.5m;
                            break;

                        case '6':
                            res += 0.6m;
                            break;

                        case '7':
                            res += 0.7m;
                            break;

                        case '8':
                            res += 0.8m;
                            break;

                        case '9':
                            res += 0.9m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 1)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00m;
                            break;

                        case '1':
                            res += 0.01m;
                            break;

                        case '2':
                            res += 0.02m;
                            break;

                        case '3':
                            res += 0.03m;
                            break;

                        case '4':
                            res += 0.04m;
                            break;

                        case '5':
                            res += 0.05m;
                            break;

                        case '6':
                            res += 0.06m;
                            break;

                        case '7':
                            res += 0.07m;
                            break;

                        case '8':
                            res += 0.08m;
                            break;

                        case '9':
                            res += 0.09m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 2)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000m;
                            break;

                        case '1':
                            res += 0.001m;
                            break;

                        case '2':
                            res += 0.002m;
                            break;

                        case '3':
                            res += 0.003m;
                            break;

                        case '4':
                            res += 0.004m;
                            break;

                        case '5':
                            res += 0.005m;
                            break;

                        case '6':
                            res += 0.006m;
                            break;

                        case '7':
                            res += 0.007m;
                            break;

                        case '8':
                            res += 0.008m;
                            break;

                        case '9':
                            res += 0.009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 3)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000m;
                            break;

                        case '1':
                            res += 0.0001m;
                            break;

                        case '2':
                            res += 0.0002m;
                            break;

                        case '3':
                            res += 0.0003m;
                            break;

                        case '4':
                            res += 0.0004m;
                            break;

                        case '5':
                            res += 0.0005m;
                            break;

                        case '6':
                            res += 0.0006m;
                            break;

                        case '7':
                            res += 0.0007m;
                            break;

                        case '8':
                            res += 0.0008m;
                            break;

                        case '9':
                            res += 0.0009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 4)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000m;
                            break;

                        case '1':
                            res += 0.00001m;
                            break;

                        case '2':
                            res += 0.00002m;
                            break;

                        case '3':
                            res += 0.00003m;
                            break;

                        case '4':
                            res += 0.00004m;
                            break;

                        case '5':
                            res += 0.00005m;
                            break;

                        case '6':
                            res += 0.00006m;
                            break;

                        case '7':
                            res += 0.00007m;
                            break;

                        case '8':
                            res += 0.00008m;
                            break;

                        case '9':
                            res += 0.00009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 5)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000m;
                            break;

                        case '1':
                            res += 0.000001m;
                            break;

                        case '2':
                            res += 0.000002m;
                            break;

                        case '3':
                            res += 0.000003m;
                            break;

                        case '4':
                            res += 0.000004m;
                            break;

                        case '5':
                            res += 0.000005m;
                            break;

                        case '6':
                            res += 0.000006m;
                            break;

                        case '7':
                            res += 0.000007m;
                            break;

                        case '8':
                            res += 0.000008m;
                            break;

                        case '9':
                            res += 0.000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 6)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000m;
                            break;

                        case '1':
                            res += 0.0000001m;
                            break;

                        case '2':
                            res += 0.0000002m;
                            break;

                        case '3':
                            res += 0.0000003m;
                            break;

                        case '4':
                            res += 0.0000004m;
                            break;

                        case '5':
                            res += 0.0000005m;
                            break;

                        case '6':
                            res += 0.0000006m;
                            break;

                        case '7':
                            res += 0.0000007m;
                            break;

                        case '8':
                            res += 0.0000008m;
                            break;

                        case '9':
                            res += 0.0000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 7)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000m;
                            break;

                        case '1':
                            res += 0.00000001m;
                            break;

                        case '2':
                            res += 0.00000002m;
                            break;

                        case '3':
                            res += 0.00000003m;
                            break;

                        case '4':
                            res += 0.00000004m;
                            break;

                        case '5':
                            res += 0.00000005m;
                            break;

                        case '6':
                            res += 0.00000006m;
                            break;

                        case '7':
                            res += 0.00000007m;
                            break;

                        case '8':
                            res += 0.00000008m;
                            break;

                        case '9':
                            res += 0.00000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 8)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000m;
                            break;

                        case '1':
                            res += 0.000000001m;
                            break;

                        case '2':
                            res += 0.000000002m;
                            break;

                        case '3':
                            res += 0.000000003m;
                            break;

                        case '4':
                            res += 0.000000004m;
                            break;

                        case '5':
                            res += 0.000000005m;
                            break;

                        case '6':
                            res += 0.000000006m;
                            break;

                        case '7':
                            res += 0.000000007m;
                            break;

                        case '8':
                            res += 0.000000008m;
                            break;

                        case '9':
                            res += 0.000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 9)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000m;
                            break;

                        case '1':
                            res += 0.0000000001m;
                            break;

                        case '2':
                            res += 0.0000000002m;
                            break;

                        case '3':
                            res += 0.0000000003m;
                            break;

                        case '4':
                            res += 0.0000000004m;
                            break;

                        case '5':
                            res += 0.0000000005m;
                            break;

                        case '6':
                            res += 0.0000000006m;
                            break;

                        case '7':
                            res += 0.0000000007m;
                            break;

                        case '8':
                            res += 0.0000000008m;
                            break;

                        case '9':
                            res += 0.0000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 10)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000m;
                            break;

                        case '1':
                            res += 0.00000000001m;
                            break;

                        case '2':
                            res += 0.00000000002m;
                            break;

                        case '3':
                            res += 0.00000000003m;
                            break;

                        case '4':
                            res += 0.00000000004m;
                            break;

                        case '5':
                            res += 0.00000000005m;
                            break;

                        case '6':
                            res += 0.00000000006m;
                            break;

                        case '7':
                            res += 0.00000000007m;
                            break;

                        case '8':
                            res += 0.00000000008m;
                            break;

                        case '9':
                            res += 0.00000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 11)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000m;
                            break;

                        case '1':
                            res += 0.000000000001m;
                            break;

                        case '2':
                            res += 0.000000000002m;
                            break;

                        case '3':
                            res += 0.000000000003m;
                            break;

                        case '4':
                            res += 0.000000000004m;
                            break;

                        case '5':
                            res += 0.000000000005m;
                            break;

                        case '6':
                            res += 0.000000000006m;
                            break;

                        case '7':
                            res += 0.000000000007m;
                            break;

                        case '8':
                            res += 0.000000000008m;
                            break;

                        case '9':
                            res += 0.000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 12)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 13)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 14)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000000m;
                            break;

                        case '1':
                            res += 0.000000000000001m;
                            break;

                        case '2':
                            res += 0.000000000000002m;
                            break;

                        case '3':
                            res += 0.000000000000003m;
                            break;

                        case '4':
                            res += 0.000000000000004m;
                            break;

                        case '5':
                            res += 0.000000000000005m;
                            break;

                        case '6':
                            res += 0.000000000000006m;
                            break;

                        case '7':
                            res += 0.000000000000007m;
                            break;

                        case '8':
                            res += 0.000000000000008m;
                            break;

                        case '9':
                            res += 0.000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 15)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 16)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 17)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000000000m;
                            break;

                        case '1':
                            res += 0.000000000000000001m;
                            break;

                        case '2':
                            res += 0.000000000000000002m;
                            break;

                        case '3':
                            res += 0.000000000000000003m;
                            break;

                        case '4':
                            res += 0.000000000000000004m;
                            break;

                        case '5':
                            res += 0.000000000000000005m;
                            break;

                        case '6':
                            res += 0.000000000000000006m;
                            break;

                        case '7':
                            res += 0.000000000000000007m;
                            break;

                        case '8':
                            res += 0.000000000000000008m;
                            break;

                        case '9':
                            res += 0.000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 18)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 19)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 20)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000000000000m;
                            break;

                        case '1':
                            res += 0.000000000000000000001m;
                            break;

                        case '2':
                            res += 0.000000000000000000002m;
                            break;

                        case '3':
                            res += 0.000000000000000000003m;
                            break;

                        case '4':
                            res += 0.000000000000000000004m;
                            break;

                        case '5':
                            res += 0.000000000000000000005m;
                            break;

                        case '6':
                            res += 0.000000000000000000006m;
                            break;

                        case '7':
                            res += 0.000000000000000000007m;
                            break;

                        case '8':
                            res += 0.000000000000000000008m;
                            break;

                        case '9':
                            res += 0.000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 21)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 22)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 23)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 24)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 25)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 26)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.000000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.000000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.000000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.000000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.000000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.000000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.000000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.000000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.000000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.000000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 27)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.0000000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.0000000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.0000000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.0000000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.0000000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.0000000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.0000000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.0000000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.0000000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.0000000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
                if (i == 28)
                {
                    switch (Value[i])
                    {
                        case '0':
                            res += 0.00000000000000000000000000000m;
                            break;

                        case '1':
                            res += 0.00000000000000000000000000001m;
                            break;

                        case '2':
                            res += 0.00000000000000000000000000002m;
                            break;

                        case '3':
                            res += 0.00000000000000000000000000003m;
                            break;

                        case '4':
                            res += 0.00000000000000000000000000004m;
                            break;

                        case '5':
                            res += 0.00000000000000000000000000005m;
                            break;

                        case '6':
                            res += 0.00000000000000000000000000006m;
                            break;

                        case '7':
                            res += 0.00000000000000000000000000007m;
                            break;

                        case '8':
                            res += 0.00000000000000000000000000008m;
                            break;

                        case '9':
                            res += 0.00000000000000000000000000009m;
                            break;
                    }
                }
                //---------------------------------------------
            }
            //-------------------------------------------------

            return res;
        }
        //-----------------------------------------------------
        public struct _DrawPos
        {
            public int L;
            public int T;

            public int Width;
            public int Height;
        }
        //-----------------------------------------------------
        private static void Clear(_DrawPos DrawPos)
        {
            Console.CursorVisible = false;

            for (int X = 0; X < DrawPos.Width; X++)
            {
                for (int Y = 0; Y < DrawPos.Height; Y++)
                {
                    Console.SetCursorPosition(DrawPos.L + X, DrawPos.T + Y);
                    Console.Write(' ');
                }
            }

            Console.CursorVisible = true;
        }
        //-----------------------------------------------------
        public struct _MathStruct
        {
            public string Value;

            public char? MathSymbol;

            public decimal? MathResult;
        }
        //-----------------------------------------------------
        public static void DrawCalculator(_DrawPos DrawPos, _DrawPos ResultPos)
        {
            //-------------------------------------------------
            bool DotStatus = false;

            string MathMask = "+-*/%$^";
            //-------------------------------------------------
            int MaxLength = 25;
            //-------------------------------------------------
            int MathIndex = 0;

            _MathStruct[] MathStruct_Mass = null;
            //-------------------------------------------------
            Console.CursorVisible = false;

            ConsoleKeyInfo PressKey;
            //-------------------------------------------------
            while (true)
            {
                //---------------------------------------------
                if (MathStruct_Mass == null)
                {
                    MathStruct_Mass = new _MathStruct[1];

                    MathStruct_Mass[0].Value = "";
                    MathStruct_Mass[0].MathSymbol = null;
                    MathStruct_Mass[0].MathResult = null;

                    MathIndex = 0;

                    MaxLength = 25;
                    DotStatus = false;

                    Clear(ResultPos);
                    Clear(DrawPos);

                    Console.SetCursorPosition(DrawPos.L, DrawPos.T);

                    Console.CursorVisible = true;
                }
                //---------------------------------------------

                PressKey = Console.ReadKey(true);

                //---------------------------------------------
                if (PressKey.Key == ConsoleKey.Delete)
                {
                    MathStruct_Mass = null;

                    continue;
                }
                //---------------------------------------------
                if (PressKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                //---------------------------------------------
                if (PressKey.Key == ConsoleKey.Backspace && MathStruct_Mass[MathIndex].Value.Length > 0)
                {
                    if (MathStruct_Mass[MathIndex].Value[MathStruct_Mass[MathIndex].Value.Length - 1] == '-')
                    {
                        MaxLength--;
                    }

                    if (MathStruct_Mass[MathIndex].Value[MathStruct_Mass[MathIndex].Value.Length - 1] == '.')
                    {
                        DotStatus = false;

                        MaxLength--;
                    }

                    Console.SetCursorPosition(DrawPos.L + MathStruct_Mass[MathIndex].Value.Length - 1, DrawPos.T);
                    Console.Write(' ');

                    MathStruct_Mass[MathIndex].Value = MathStruct_Mass[MathIndex].Value.Substring(0,
                                   MathStruct_Mass[MathIndex].Value.Length - 1);
                }
                //---------------------------------------------
                if (PressKey.Key == ConsoleKey.Enter)
                {
                    if (MathStruct_Mass.Length == 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (String_DecimalOrNotDecimal(MathStruct_Mass[MathIndex].Value) == false)
                        {
                            continue;
                        }

                        decimal xres = (decimal)MathStruct_Mass[0].MathResult;

                        MathStruct_Mass[MathIndex].MathResult = StringToDecimal(MathStruct_Mass[MathIndex].Value);

                        string err = "";

                        for (int i = 0; i < MathStruct_Mass.Length; i++)
                        {
                            switch (MathStruct_Mass[i].MathSymbol)
                            {
                                case '+':
                                    xres += (decimal)MathStruct_Mass[i + 1].MathResult;
                                    break;

                                case '-':
                                    xres -= (decimal)MathStruct_Mass[i + 1].MathResult;
                                    break;

                                case '*':
                                    xres *= (decimal)MathStruct_Mass[i + 1].MathResult;
                                    break;

                                case '%':
                                    if (MathStruct_Mass[i + 1].MathResult == 0)
                                    {
                                        err = "Ошибка: Деление на ноль невозможно!";

                                        break;
                                    }
                                    xres %= (decimal)MathStruct_Mass[i + 1].MathResult;
                                    break;

                                case '^':
                                    xres = (decimal)IntToExp((int)xres, (int)MathStruct_Mass[i + 1].MathResult);
                                    break;

                                case '/':
                                    if (MathStruct_Mass[i + 1].MathResult == 0)
                                    {
                                        err = "Ошибка: Деление на ноль невозможно!";

                                        break;
                                    }
                                    xres /= (decimal)MathStruct_Mass[i + 1].MathResult;
                                    break;
                            }
                        }

                        Clear(DrawPos);
                        Clear(ResultPos);

                        Console.CursorVisible = false;

                        if (err.Length > 0)
                        {
                            Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                            Console.WriteLine(err);
                        }
                        else
                        {
                            Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                            Console.Write("Результат: = " + xres.ToString());
                        }

                        Console.SetCursorPosition(DrawPos.L, DrawPos.T);
                        Console.Write("Нажми любую клавишу!");

                        Console.ReadKey(true);

                        MathStruct_Mass = null;

                        continue;
                    }
                }
                //---------------------------------------------
                _MathStruct[] buff = null;

                for (int i = 0; i < MathMask.Length; i++)
                {
                    if (String_DecimalOrNotDecimal(MathStruct_Mass[MathIndex].Value) == false)
                    {
                        break;
                    }

                    if (PressKey.KeyChar == MathMask[i])
                    {
                        MathStruct_Mass[MathIndex].MathSymbol = PressKey.KeyChar;
                        MathStruct_Mass[MathIndex].MathResult = (decimal)StringToDecimal(MathStruct_Mass[MathIndex].Value);

                        buff = MathStruct_Mass;
                        MathStruct_Mass = new _MathStruct[buff.Length + 1];

                        for (int i1 = 0; i1 < buff.Length; i1++)
                        {
                            MathStruct_Mass[i1].Value = buff[i1].Value;
                            MathStruct_Mass[i1].MathSymbol = buff[i1].MathSymbol;
                            MathStruct_Mass[i1].MathResult = buff[i1].MathResult;
                        }

                        MathStruct_Mass[MathStruct_Mass.Length - 1].Value = "";
                        MathStruct_Mass[MathStruct_Mass.Length - 1].MathSymbol = null;
                        MathStruct_Mass[MathStruct_Mass.Length - 1].MathResult = null;

                        MaxLength = 25;
                        DotStatus = false;

                        Clear(DrawPos);
                        Clear(ResultPos);

                        Console.CursorVisible = false;

                        if (MathIndex == 0)
                        {
                            Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                            Console.Write(MathStruct_Mass[MathIndex].Value + " " + MathStruct_Mass[MathIndex].MathSymbol);
                        }

                        string err = "";

                        if (MathIndex >= 1)
                        {
                            decimal xres = (decimal)MathStruct_Mass[0].MathResult;

                            for (int x = 0; x < MathIndex; x++)
                            {
                                switch (MathStruct_Mass[x].MathSymbol)
                                {
                                    case '+':
                                        xres += (decimal)MathStruct_Mass[x + 1].MathResult;
                                        break;

                                    case '-':
                                        xres -= (decimal)MathStruct_Mass[x + 1].MathResult;
                                        break;

                                    case '*':
                                        xres *= (decimal)MathStruct_Mass[x + 1].MathResult;
                                        break;

                                    case '^':
                                        xres = (decimal)IntToExp((int)xres, (int)MathStruct_Mass[x + 1].MathResult);
                                        break;

                                    case '%':
                                        if (MathStruct_Mass[x + 1].MathResult == 0)
                                        {
                                            err = "Ошибка: Деление на ноль невозможно!";

                                            break;
                                        }

                                        xres %= (decimal)MathStruct_Mass[x + 1].MathResult;
                                        break;

                                    case '/':
                                        if (MathStruct_Mass[x + 1].MathResult == 0)
                                        {
                                            err = "Ошибка: Деление на ноль невозможно!";

                                            break;
                                        }

                                        xres /= (decimal)MathStruct_Mass[x + 1].MathResult;
                                        break;
                                }
                            }

                            if (err.Length > 0)
                            {
                                Clear(ResultPos);
                                Clear(DrawPos);

                                Console.CursorVisible = false;

                                Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                                Console.Write(err);

                                Console.SetCursorPosition(DrawPos.L, DrawPos.T);
                                Console.Write("Нажми любую клавишу!");

                                Console.ReadKey(true);

                                MathStruct_Mass = null;

                                break;

                            }

                            Console.SetCursorPosition(ResultPos.L, ResultPos.T);

                            Console.Write(xres + " " + MathStruct_Mass[MathIndex].MathSymbol);
                        }

                        if (MathStruct_Mass[MathIndex].MathSymbol == '$')
                        {
                            Clear(ResultPos);
                            Clear(DrawPos);

                            Console.CursorVisible = false;

                            if (MathStruct_Mass[MathIndex].MathResult < 0)
                            {
                                err = "Ошибка: Невозможно рассчитать 2Корень отрицательного числа!";

                                Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                                Console.WriteLine(err);

                                Console.SetCursorPosition(DrawPos.L, DrawPos.T);
                                Console.WriteLine("Нажми любую клавишу!");

                                Console.ReadKey(true);

                                MathStruct_Mass = null;

                                break;
                            }
                            else
                            {
                                Console.SetCursorPosition(ResultPos.L, ResultPos.T);
                                Console.WriteLine("Результат: = " + IntToSqrt((double)MathStruct_Mass[MathIndex].MathResult));

                                Console.SetCursorPosition(DrawPos.L, DrawPos.T);
                                Console.WriteLine("Нажми любую клавишу!");

                                Console.ReadKey(true);

                                MathStruct_Mass = null;

                                break;
                            }
                        }

                        MathIndex++;

                        break;
                    }
                }
                //---------------------------------------------
                if (buff != null || MathStruct_Mass == null)
                {
                    Console.SetCursorPosition(DrawPos.L, DrawPos.T);
                    Console.CursorVisible = true;

                    continue;
                }
                //---------------------------------------------
                if (MathStruct_Mass[MathIndex].Value.Length == MaxLength)
                {
                    continue;
                }
                //---------------------------------------------
                if (MathStruct_Mass[MathIndex].Value.Length == 0)
                {
                    if (PressKey.KeyChar == '-')
                    {
                        MathStruct_Mass[MathIndex].Value = "-";

                        MaxLength++;
                    }
                }
                //---------------------------------------------
                if (PressKey.KeyChar == '.' && DotStatus == false)
                {
                    if (MathStruct_Mass[MathIndex].Value.Length >= 1 &&
                      
                        MathStruct_Mass[MathIndex].Value[MathStruct_Mass[MathIndex].Value.Length - 1] != '-')
                    {
                        MathStruct_Mass[MathIndex].Value += '.';

                        MaxLength++;

                        DotStatus = true;
                    }
                }
                //---------------------------------------------
                if (CharUnicodeInfo.GetUnicodeCategory(PressKey.KeyChar) == CharUnicodeInfo.GetUnicodeCategory('1'))
                {
                    MathStruct_Mass[MathIndex].Value += PressKey.KeyChar;
                }
                //---------------------------------------------
                Console.CursorVisible = false;
                Console.SetCursorPosition(DrawPos.L, DrawPos.T);

                Console.Write(MathStruct_Mass[MathIndex].Value);

                Console.CursorVisible = true;
                //---------------------------------------------
            }
        }
        //-----------------------------------------------------
    }
}
