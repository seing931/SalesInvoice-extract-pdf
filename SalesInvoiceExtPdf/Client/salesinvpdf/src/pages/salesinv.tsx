import React, { useState } from "react";
import PdfUpload from "../components/pdfupd";
import SalesInvForm from "../components/salesinvform";

import {
  uploadInvoicePdf,
  saveInvoice,
} from "../api/salesinvapi";

import type { sales } from "../type/sales";

const salesinv: React.FC = () => {
  const [invoice, setInvoice] = useState<sales | null>(null);
  const [loading, setLoading] = useState(false);

  const handleUpload = async (file: File) => {
    try {
      setLoading(true);

      const data = await uploadInvoicePdf(file);

      setInvoice(data);
    } catch (err) {
      alert("Upload failed");
    } finally {
      setLoading(false);
    }
  };

  const handleSave = async () => {
    if (!invoice) return;

    try {
      await saveInvoice(invoice);
      alert("Saved successfully");
    } catch {
      alert("Save failed");
    }
  };

  return (
    <div style={{ padding: 30 }}>
       <div className="title" style={{ textAlign: "left" }}>Invoice Processing System</div>
      <PdfUpload onFileUpload={handleUpload} />

      {loading && <p>Processing PDF...</p>}

      {invoice && (
        <SalesInvForm
          invoice={invoice}
          setInvoice={setInvoice}
          onSave={handleSave}
        />
      )}

    </div>
  );
};

export default salesinv;