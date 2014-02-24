using System;

namespace MortCalc
{
    public static class Calculation
    {

        public static decimal GetPayment(decimal mAmount = 0, double mIntrestRate = 0, double mLength = 0)
        {
            double PVal = 0;
            double APR = 0;
            double TotPmts = 0;
            double Payment = 0;
            double PointOh = 0;

            PVal = Convert.ToDouble(mAmount);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR / 100; // Ensure proper form.
            }

            TotPmts = mLength * 12;

            // here is the actual formula!
            PointOh = 1 + (APR * 100) / 1200;
            Payment = (PVal * (APR * 100) * (Math.Pow(PointOh, TotPmts))) / (1200 * (Math.Pow(PointOh, TotPmts) - 1));

            return Math.Round(System.Convert.ToDecimal(Payment), 2);
        }

        public static decimal RunLoan(ref int paynum, decimal mAmount, double mIntrestRate, double mLength, decimal mpayment )
        {
            double PVal = 0;
            double APR = 0;
            double Payment = 0;
            decimal Intrest = 0;
            decimal Principal = 0;

            Payment = Convert.ToDouble(mpayment);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR / 100; // Ensure proper form.
            }
            PVal = Convert.ToDouble(mAmount);
            Intrest = Math.Round(System.Convert.ToDecimal(PVal * (APR) / 12), 2);
            Principal = Math.Round(System.Convert.ToDecimal(Payment - System.Convert.ToDouble(Intrest)), 2);

            if (Payment > (double) mAmount)
            {
                Payment = (double) (mAmount);
                Principal = Math.Round(Convert.ToDecimal(Payment - (double) Intrest), 2);
                Console.WriteLine("{0}: {1:F} - {2:F} - {3:F} - {4:F}", paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                return 0;
            } 

            Console.WriteLine("{0}-{1:F}-{2:F}-{3:F}-{4:F}", paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));

            decimal result = System.Convert.ToDecimal(mAmount) - Math.Round(System.Convert.ToDecimal(Principal), 2);

            return result;
        }


        public static decimal Calculate(decimal mAmount = 0, double mIntrestRate = 0, double mLength = 0)
        {
            double PVal = 0;
            double APR = 0;
            double TotPmts = 0;
            double Payment = 0;
            decimal Intrest = 0;
            decimal Principal = 0;
            double PointOh = 0;
            double PointOhOne = 0;
            int PayType = 0;
            string cFormat = string.Empty;

            string m_LengthInterval = "Years";
            int m_Beginning = 0;

            //UpdateData(TRUE);
            //if (m_Amount == 0) return;
            //if (m_IntrestRate == 0) return;
            //if (m_Length == 0) return;

            //Fmt = "###,###,##0.00"; // Define money format.
            //FVal = 0; // Usually 0 for a loan.
            PVal = Convert.ToDouble(mAmount);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR/100; // Ensure proper form.
            }

            TotPmts = mLength;
            if (m_LengthInterval == "Years")
            {
                TotPmts = TotPmts*12;
            }


            if (m_Beginning == 0)
            {
                PayType = 1; // BEGINPERIOD
            }
            else
            {
                PayType = 0; // ENDPERIOD
            }

// here is a function that derives the payment...
// Payment = Pmt(APR / 12, TotPmts, -PVal, FVal, PayType)

// here is the actual formula!
            PointOh = 1 + (APR*100)/1200;
            PointOhOne = Math.Pow(PointOh, TotPmts);
            Payment = (PVal*(APR*100)*(Math.Pow(PointOh, TotPmts)))/(1200*(Math.Pow(PointOh, TotPmts) - 1));
            //Console.WriteLine(cFormat, "%0.2f", Payment);

            // Payment = System.Convert.ToDouble(cFormat);
            decimal m_Payment = Math.Round(System.Convert.ToDecimal(Payment), 2);

            //m_Payment = m_Payment.To

//Amortize TotPmts, PVal, APR, TxtPayment.Text

            Intrest =  Math.Round(System.Convert.ToDecimal(PVal*(APR)/12), 2);
            Principal = Math.Round(System.Convert.ToDecimal(Payment - System.Convert.ToDouble(Intrest)), 2);
            Console.WriteLine("1 - {0} - {1} - {2}", Math.Round(System.Convert.ToDecimal(Payment), 2), Intrest, Principal);

            decimal result = System.Convert.ToDecimal(mAmount) - Math.Round(System.Convert.ToDecimal(Principal), 2);

            return result;

            //m_LstSchedule.AddString(cFormat);

            //UpdateData(FALSE);

            //FillListCtrl();

            //UpdateData(FALSE);

/*
Example.  Find the monthly repayments on a loan of $20,000 over 15 
years at 12 percent per year compound interest.

Here we have n = 12*15 = 180 months, r = 12, and L = 20000.
We want to find P.

1+r/1200 = 1 + 12/1200 = 1.01   and the above formula becomes


       P = {20000*12*1.01^180}/{1200*(1.01^180 - 1)}

         = {20000*12*5.99}/{1200*(5.99 - 1)}

         = 1437600/5988
 
         = $240.08
*/

        }

//public void FillListCtrl()
//{
////	int             iIcon, iSubItem, iActualItem;
//    int             iItem;
//    LV_ITEM         lvitem;
//    CString         strStuff, strIconDesc[4], strIconShortDesc[4];
////	LPTSTR          pStrTemp1, pStrTemp2;
//    char cFormat[256];
//    double TotPmts;
//    double TotIntrest;
//    double PrePayment;
//    double OldPrePayment;
//    double Payment;
//    double Intrest;
//    double Principal;
//    double NewBalance;
//    double CurrentBalance;
//    double PointOh;
//    UINT PaymentInterval;
//    BOOL ApplyPrePayment;
////	UINT PayType;

//    m_listctrl.DeleteAllItems();
//    TotPmts = PrePayment = Payment = Intrest = Principal = OldPrePayment = 0;
//    NewBalance = CurrentBalance = PointOh = TotIntrest = 0;
//    PaymentInterval = 0;
//    CurrentBalance = m_Amount;
//    PointOh = 1 + (m_IntrestRate) / 1200;
//    TotPmts = m_Length;
//    if (m_LengthInterval == "Years" ) {
//        TotPmts = TotPmts * 12;
//    }

//    if ( m_RegularPayment > 0 ) {
//        PrePayment = m_RegularPayment;
//        PaymentInterval = m_RegularMonth;
//    } else {
//        PrePayment = 0;
//        PaymentInterval = 0;
//    }

//    Payment = ( CurrentBalance*(m_IntrestRate)* (pow(PointOh,TotPmts))  ) / (1200* ( pow ( PointOh, TotPmts ) - 1) );
//    sprintf(cFormat, "%0.2f", Payment);
//    Payment = atof(cFormat);
	
//    iItem = 1;
//    while ( CurrentBalance > 0 ) {
//        if ( m_OneTimePayment && m_OneTime && iItem == m_OneTime) {
//            OldPrePayment = PrePayment;
//            PrePayment = PrePayment + m_OneTimePayment;
//        }
//        if ( CurrentBalance < Payment ) {
//            PrePayment = 0;
//            Intrest = CurrentBalance * (m_IntrestRate/100) / 12;
//            Principal = CurrentBalance - Intrest;
//            NewBalance = (CurrentBalance - (Principal + Intrest));
//        } else {	
//            Intrest = CurrentBalance * (m_IntrestRate/100) / 12;
//            Principal = m_Payment - Intrest;
//            ApplyPrePayment = false;
//            if ( PrePayment > 0 && m_PrePayInterval == "Yearly" ) {
//                if ( iItem >= (int)PaymentInterval ) {
//                    if ( (iItem - PaymentInterval == 0 ) || ( ((long)iItem - (long)PaymentInterval ) % 12 ) == 0 ) {
//                        ApplyPrePayment = true;
//                    }
//                }
//            } else {
//                NewBalance = CurrentBalance - Principal - (iItem >= (int)PaymentInterval ? PrePayment : 0);
//            }
//            if ( ApplyPrePayment ) {
//                NewBalance = CurrentBalance - Principal - PrePayment;
//            } else {
//                if ( m_PrePayInterval == "Yearly" && !ApplyPrePayment ) {
//                    NewBalance = CurrentBalance - Principal;
//                }
//            }
//        }
//        if ( m_OneTimePayment && m_OneTime && iItem == m_OneTime) {
//            NewBalance = NewBalance - m_OneTimePayment;
//        }
//        if ( NewBalance < 0 ) {
//            if ( m_PrePayInterval == "Monthly" || ApplyPrePayment ) {
//                if ( labs((long)NewBalance) <= PrePayment ) {
//                    PrePayment = PrePayment + NewBalance;
//                    NewBalance = (CurrentBalance - (Principal + PrePayment));
//                } else {
//                    PrePayment = 0;
//// if I actually need this then NewBalance will need to be recalculated!
//                }
//            }
//        }

//// insert the items and subitems into the list view.
//        lvitem.mask = LVIF_TEXT;
//        lvitem.iItem = iItem-1; // 0 based
//        lvitem.iSubItem = 0;
//        sprintf(cFormat, "%d", iItem);
//        lvitem.pszText = cFormat;
//        m_listctrl.InsertItem(&lvitem); // modify existing item (the sub-item text)

//        lvitem.iSubItem = 1;
//        sprintf(cFormat, "%0.2f", CurrentBalance);
//        lvitem.pszText = cFormat;
//        m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
		
//        lvitem.iSubItem = 2;
//        sprintf(cFormat, "%0.2f", Intrest);
//        lvitem.pszText = cFormat;
//        m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)

//        lvitem.iSubItem = 3;
//        sprintf(cFormat, "%0.2f", Principal);
//        lvitem.pszText = cFormat;
//        m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)

//        lvitem.iSubItem = 4;
//        sprintf(cFormat, "%0.2f", Principal+Intrest);
//        lvitem.pszText = cFormat;
//        m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)

//        if ( m_PrePayInterval == "Monthly" || ( m_OneTimePayment && (long)iItem == m_OneTime )) {
//            if ( (m_OneTimePayment && (long)iItem == m_OneTime) && (m_OneTime < m_RegularMonth) ) {
//                lvitem.iSubItem = 5;
//                sprintf(cFormat, "%0.2f", m_OneTimePayment );
//                lvitem.pszText = cFormat;
//                m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
//            } else {
//                lvitem.iSubItem = 5;
//                sprintf(cFormat, "%0.2f", (iItem > m_RegularMonth) ? PrePayment : 0 );
//                lvitem.pszText = cFormat;
//                m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
//            }
//        } else {
//            lvitem.iSubItem = 5;
//            sprintf(cFormat, "%0.2f", ApplyPrePayment ? PrePayment : 0 );
//            lvitem.pszText = cFormat;
//            m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
//        }

//        lvitem.iSubItem = 6;
//        sprintf(cFormat, "%0.2f", NewBalance);
//        lvitem.pszText = cFormat;
//        m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
//        CurrentBalance = NewBalance;
//        if ( m_OneTimePayment && m_OneTime && iItem == m_OneTime) {
//            PrePayment = OldPrePayment;
//        }
//        iItem++;
//        TotIntrest = TotIntrest+Intrest;
//    }
//    iItem--;
//    sprintf(cFormat, "%d Payments or %d Years and %d  Months", iItem, iItem / 12, iItem % 12 );
//    m_Duration = cFormat;
//    sprintf(cFormat, "%0.2f", TotIntrest );
//    m_StrIntrestTotal = cFormat;

// /*
//    for (iItem = 0; iItem < 20; iItem++)  // insert the items and subitems into the list view.
//        for (iSubItem = 0; iSubItem < 2; iSubItem++)
//        {
//            if (iSubItem == 0)
//                iIcon = rand() % 4;  // choose the icon and legend for the entry

//            lvitem.mask = LVIF_TEXT | (iSubItem == 0? LVIF_IMAGE : 0);
//            lvitem.iItem = (iSubItem == 0)? iItem : iActualItem;
//            lvitem.iSubItem = iSubItem;

//            // calculate the main and sub-item strings for the current item
//            pStrTemp1= strIconShortDesc[iIcon].GetBuffer(strIconShortDesc[iIcon].GetLength());
//            pStrTemp2= strIconDesc[iIcon].GetBuffer(strIconDesc[iIcon].GetLength());
//            lvitem.pszText = iSubItem == 0? pStrTemp1 : pStrTemp2;

//            lvitem.iImage = iIcon;
//            if (iSubItem == 0)
//                iActualItem = m_listctrl.InsertItem(&lvitem); // insert new item
//            else
//                m_listctrl.SetItem(&lvitem); // modify existing item (the sub-item text)
//        }
//*/
	
//}

//public void ModifyHeaderItems()
//{
//    CRect           rect;
//    HD_ITEM curItem;
//    CMortCalcApp     *pApp;
//    CString         strItem1= _T("ITEM");
//    CString         strItem2= _T("SUB_ITEM");
//    pApp = (CMortCalcApp *)AfxGetApp();

//// insert two columns (REPORT mode) and modify the new header items
//    m_listctrl.GetWindowRect(&rect);
//    m_listctrl.InsertColumn(0, strItem1, LVCFMT_LEFT,
//        rect.Width() * 4/32, 0);
//    m_listctrl.InsertColumn(1, strItem2, LVCFMT_LEFT,
//        rect.Width() * 6/32, 1);
//    m_listctrl.InsertColumn(2, strItem2, LVCFMT_LEFT,
//        rect.Width() * 4/32, 2);
//    m_listctrl.InsertColumn(3, strItem2, LVCFMT_LEFT,
//        rect.Width() * 4/32, 3);
//    m_listctrl.InsertColumn(4, strItem2, LVCFMT_LEFT,
//        rect.Width() * 4/32, 4);
//    m_listctrl.InsertColumn(5, strItem2, LVCFMT_LEFT,
//        rect.Width() * 4/32, 5);
//    m_listctrl.InsertColumn(6, strItem2, LVCFMT_LEFT,
//        rect.Width() * 6/32, 6);
////MoodifyHeaderItems();

//    // retrieve embedded header control
//    CHeaderCtrl* pHdrCtrl= NULL;
//    pHdrCtrl= m_listctrl.GetHeaderCtrl();

////	pHdrCtrl->SetImageList(m_pImageHdrSmall);
//    // add bmaps to each header item
////	pHdrCtrl->GetItem(0, &curItem);
//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Payment";
//    curItem.cchTextMax = 4;
//    pHdrCtrl->SetItem(0, &curItem);

////	pHdrCtrl->GetItem(1, &curItem);
//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Balance";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(1, &curItem);

////	pHdrCtrl->GetItem(2, &curItem);
//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Interest";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(2, &curItem);

////	pHdrCtrl->GetItem(3, &curItem);
//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Principal";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(3, &curItem);

////	pHdrCtrl->GetItem(4, &curItem);
//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Total P&I";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(4, &curItem);

//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "Pre-Paid";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(5, &curItem);

//    curItem.mask= HDI_TEXT;
//    curItem.pszText = "New Balance";
//    curItem.cchTextMax = 20;
//    pHdrCtrl->SetItem(6, &curItem);
//}





}
}