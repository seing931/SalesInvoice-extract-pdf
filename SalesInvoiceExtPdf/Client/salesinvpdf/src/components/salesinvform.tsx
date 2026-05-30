import React from "react";
import type {sales} from "../type/sales";
import SalesItemsTable from "./salesitemstable";

interface Props {
  invoice: sales;
  setInvoice: React.Dispatch<React.SetStateAction<sales | null>>;
  onSave: () => void;
}

const salesinvform: React.FC<Props> = ({
  invoice,
  setInvoice,
  onSave,
}) => {
  const handleChange = (
    field: keyof sales,
    value: any
  ) => {
    setInvoice({
      ...invoice,
      [field]: value,
    });
  };

  return (
 <div style={{ padding: 30 }}>
   <div className="header">
    <div className="invoice-title">SALES INVOICE</div>
    <div className="invoice-meta">
      <div><strong>Order ID :</strong> 
          {invoice.orderID}
      </div>
      <div><strong>Date:</strong> 
          {invoice.invDate}
      </div>
      <div><strong>Ship Mode:</strong> 
          {invoice.shipMode}
      </div>
    </div>
   </div>
  <div className="content">
    <div className="parties">
      <div className="party" style={{ textAlign: "left" }}>
        <h3>Bill To</h3>
        <strong>
          {invoice.billTo}
        </strong>
      </div>
      <div className="party" style={{ textAlign: "right" }}>
        <h3>Ship To</h3>
          {invoice.shipTo}
        </div>
      </div>
    </div>
    <div style={{ marginTop: 20 }}>
         <SalesItemsTable items={invoice.items} />
    </div>
    <table className="totals">
      <tr>
        <td>Discount :</td>
         <td style={{ textAlign: "right" }}>
            {invoice.discPrc}
        </td>
      </tr>
      <tr>
        <td>Shipping :</td>
        <td style={{ textAlign: "right" }}>
           {invoice.shipping}
        </td>
      </tr>
      <tr className="total-row">
        <td>Total:</td>
        <td style={{ textAlign: "right" }}>
        </td>
      </tr>
    </table>
   <div className="button-container">
      <button className="button-72" onClick={onSave}>Save</button>
     </div>
  </div>
  );
};

export default salesinvform;