/*
 * Pavel Dev
 * GitHub: PavelDev91
 * E-mail: PavelDev1991@gmail.com
 */

using System;

using _MyFunc;

//-----------------------------------------------------------------------------------------------------------------------------
public class MyProduct
{
    private string productID;

    private int productPrice;

    private int productCount;
    //---------------------------------------------------------
    public MyProduct(string id) : this(id, 0, 0)
    {
    }
    //-------------------------
    public MyProduct(string id, int price) : this(id, price, 0)
    {
    }
    //-------------------------
    public MyProduct(string id, int price, int count)
    {
        productID = id;
        productPrice = price;
        productCount = count;
    }
    //---------------------------------------------------------
    public void Get_ProductID(out string result)
    {
        result = productID;
    }
    //---------------------------------------------------------
    public void Get_ProductPrice(out int result)
    {
        result = productPrice;
    }
    //---------------------------------------------------------
    public void Get_ProductCount(out int result)
    {
        result = productCount;
    }
    //---------------------------------------------------------
}
//-----------------------------------------------------------------------------------------------------------------------------
public class ProductInventorySystem
{
    //---------------------------------------------------------
    private struct sProduct
    {
        public string productName;

        public MyProduct productData;
    }
    //---------------------------------------------------------
    private sProduct[] productArray;
    //---------------------------------------------------------
    public ProductInventorySystem()
    {
        productArray = null;
    }
    //---------------------------------------------------------
    public void Product_Add(string productName, int? productPrice, int? productCount)
    {
        Array_Add(ref productArray);

        string productID = GenID(productName);

        productArray[productArray.Length - 1].productName = productName;

        if (productPrice == null && productCount == null)
        {
            productArray[productArray.Length - 1].productData = new MyProduct(productID);
        }

        if (productPrice != null && productCount == null)
        {
            productArray[productArray.Length - 1].productData = new MyProduct(productID, (int)productPrice);
        }

        if (productPrice == null && productCount != null)
        {
            productArray[productArray.Length - 1].productData = new MyProduct(productID, 0, (int)productCount);
        }

        if (productPrice != null && productCount != null)
        {
            productArray[productArray.Length - 1].productData = new MyProduct(productID, (int)productPrice, (int)productCount);
        }
    }
    //---------------------------------------------------------
    public int Get_DataCount()
    {
        if (productArray == null)
        {
            return 0;
        }

        return productArray.Length;
    }
    //---------------------------------------------------------
    public string Get_ProductID(int productIndex)
    {
        if (productArray == null)
        {
            return "";
        }

        if (productIndex >= 0 && productIndex <= productArray.Length - 1)
        {
            string res;

            productArray[productIndex].productData.Get_ProductID(out res);

            return res;
        }

        return "";
    }
    //---------------------------------------------------------
    public string Get_ProductName(int productIndex)
    {
        if (productArray == null)
        {
            return "";
        }

        if (productIndex >= 0 && productIndex <= productArray.Length - 1)
        {
            return productArray[productIndex].productName;
        }

        return "";
    }
    //---------------------------------------------------------
    public int Get_ProductPrice(int productIndex)
    {
        if (productArray == null)
        {
            return 0;
        }

        if (productIndex >= 0 && productIndex <= productArray.Length - 1)
        {
            int res;

            productArray[productIndex].productData.Get_ProductPrice(out res);

            return res;
        }

        return 0;
    }
    //---------------------------------------------------------
    public int Get_ProductCount(int productIndex)
    {
        if (productArray == null)
        {
            return 0;
        }

        if (productIndex >= 0 && productIndex <= productArray.Length - 1)
        {
            int res;

            productArray[productIndex].productData.Get_ProductCount(out res);

            return res;
        }

        return 0;
    }
    //---------------------------------------------------------
    public bool DeleteProduct(string productID)
    {
        if (FindID(productID) == -1)
        {
            return false;
        }

        if (productArray.Length == 1)
        {
            productArray = null;

            return true;
        }

        sProduct[] buf = productArray;

        productArray = new sProduct[buf.Length - 1];

        string fID;

        int x = 0;

        for (int i = 0; i < buf.Length; i++)
        {
            buf[i].productData.Get_ProductID(out fID);

            if (fID.ToLower() == productID.ToLower())
            {
                continue;
            }

            productArray[x] = buf[i];

            x++;
        }

        return true;
    }
    //---------------------------------------------------------
    public void Clear()
    {
        productArray = null;
    }
    //---------------------------------------------------------
    private void Array_Add(ref sProduct[] _array)
    {
        if (_array == null)
        {
            _array = new sProduct[1];

            return;
        }

        sProduct[] buf = _array;

        _array = new sProduct[buf.Length + 1];

        for (int i = 0; i < buf.Length; i++)
        {
            _array[i] = buf[i];
        }
    }
    //---------------------------------------------------------
    public bool FindProduct(string value)
    {
        if (productArray == null || productArray.Length == 0)
        {
            return false;
        }

        for (int i = 0; i < productArray.Length; i++)
        {
            if (productArray[i].productName.ToLower() == value.ToLower())
            {
                return true;
            }
        }

        return false;
    }
    //---------------------------------------------------------
    public int FindID(string value)
    {
        if (productArray == null && productArray.Length == 0)
        {
            return -1;
        }

        string str;

        for (int i = 0; i < productArray.Length; i++)
        {
            if (productArray[i].productData == null)
            {
                continue;
            }

            productArray[i].productData.Get_ProductID(out str);

            if (value.ToLower() == str.ToLower())
            {
                return i;
            }
        }

        return -1;
    }
    //---------------------------------------------------------
    private string GenID(string value)
    {
        if (value.Length == 0)
        {
            return null;
        }

        string res;

        Random rValue = new Random();

        res = value;
        res = res.ToUpper();
        res = res[0] + "/";

        while (true)
        {
            res = res + rValue.Next(0, 257).ToString();

            if (FindID(res) == -1)
            {
                return res;
            }
        }
    }
    //---------------------------------------------------------
}
//-----------------------------------------------------------------------------------------------------------------------------