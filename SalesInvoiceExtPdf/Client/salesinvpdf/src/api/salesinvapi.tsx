import axios from "axios";
import type {sales} from "../type/sales";

const API_URL = "http://localhost:5240/api/salesinv";

export const uploadInvoicePdf = async (
  file: File
): Promise<sales> => {
  const formData = new FormData();
  formData.append("file", file);
  
  try {
  const res = await axios.post<sales>(
    `${API_URL}/extract`,
    formData,
    {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }
  );

  return res.data;
  } catch (error: any) {
    console.error(
      error.response?.data || error.message
    );

    throw error;
  }
};

export const saveInvoice = async (
  invoice: sales
) => {
  return axios.post(`${API_URL}/save`, invoice);
};