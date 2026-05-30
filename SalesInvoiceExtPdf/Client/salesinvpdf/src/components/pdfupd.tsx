import React from "react";

interface Props {
  onFileUpload: (file: File) => void;
}

const pdfupd: React.FC<Props> = ({ onFileUpload }) => {
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];

    if (file) {
      onFileUpload(file);
    }
  };

  return (
    <div className="upload-section" style={{ textAlign: "left" }}>
      <input
        type="file"
        accept="application/pdf"
        onChange={handleChange}
      />
    </div>
  );
};

export default pdfupd;