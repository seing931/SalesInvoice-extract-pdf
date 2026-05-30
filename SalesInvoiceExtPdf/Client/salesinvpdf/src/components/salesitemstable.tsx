import React from "react";
import type { salesitems } from "../type/sales";

interface Props {
  items: salesitems[];
}

const SalesItemsTable: React.FC<Props> = ({ items }) => {
  return (
    <div>
      <table>
      <thead>
        <tr>
          <th>Items</th>
          <th style={{ textAlign: "right" }}>Qty</th>
          <th style={{ textAlign: "right" }}>Rate</th>
          <th style={{ textAlign: "right" }}>Amount</th>
        </tr>
      </thead>
      <tbody>
          {items.map((item, index) => (
            <tr key={index}>
              <td>{item.itemName}</td>
              <td style={{ textAlign: "right" }}>{item.qty}</td>
              <td style={{ textAlign: "right" }}>{item.rate}</td>
              <td style={{ textAlign: "right" }}>{item.amt}</td>
            </tr>
          ))}
      </tbody>
    </table>
    </div>
  );
};

export default SalesItemsTable;