using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Partial
{
    /// <summary>
    /// 변수
    /// </summary>
    partial class CData
    {
        private double _totalPrice = 0.0;
        public double TotalPrice 
        {
            get => _totalPrice;
            set
            {
                _totalPrice = _totalPrice + value;
            }
        }

        private string _strItem = string.Empty;
        public string StrItem 
        {
            get // 읽기 전용
            { 
                return _strItem; 
            }
            set // 쓰기 전용
            {
                if(String.IsNullOrEmpty(value))
                {
                    _strErrorName = "상품이 선택되지 않았습니다.";
                }
                else
                {
                    _strItem = value;
                }
            }
        }
        private int _iRate = 0;

        public int IRate
        {
            //get
            //{
            //    return iRate;
            //}
            set
            {
                if(value>20)
                {
                    _strErrorName = "사장님만 가능한 할인입니다.";
                }
                else
                {
                    _iRate = value;
                }
                
            }
        }

        private int _iCount = 0;
        public int ICount 
        {
            //get => iCount; 
            set
            {
                if(value > 5)
                {
                    _strErrorName = "개별 상품은 5개 이상 구매할 수 없습니다.";
                }
                else if(value==0)
                {
                    _strErrorName = "물품의 개수가 0개입니다.";
                }
                else
                {
                    _iCount = value;
                }
                
            }
        }

        private string _strErrorName = string.Empty;
        public string StrErrorName
        {
            get => _strErrorName;
            // set => _strErrorName = value; 
        }
    }

    /// <summary>
    /// 수식 계산
    /// </summary>
    partial class CData
    {
        public double ItemPrice()
        {
            double dPrice = 0;

            int iItemPrice = 0;

            if(String.IsNullOrEmpty(_strErrorName)) // Error가 없으면 정상값을 받았다고 판정
            {
                iItemPrice = (int)Enum.Parse(typeof(EnumItem), _strItem);

                dPrice = iItemPrice - Math.Round((double)iItemPrice * (double)_iRate / 100, 2);
            }

            return dPrice * _iCount;
        }
    }

    /// <summary>
    /// 문자열
    /// </summary>
    partial class CData
    {
        public string Result(double dPrice)
        {
            if(_iRate == 0)
            {
                return string.Format("{0} X {1} : {2}원)", _strItem, _iCount, dPrice);
            }
            else
            {
                return string.Format("{0} X {1} : {2}원 (할인율 : {3}%)", _strItem, _iCount, dPrice, _iRate);
            }
        }

        public void DataInit()
        {
            _strErrorName = string.Empty;
            _strItem = string.Empty;
            _iRate = 0;
            _iCount = 0;
        }
    }
}
