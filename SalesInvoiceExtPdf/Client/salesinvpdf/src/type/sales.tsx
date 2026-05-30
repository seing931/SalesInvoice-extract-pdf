export interface salesitems {
  itemName: string;
  itemDesc: string;
  qty: number;
  rate: number;
  amt: number;
}

export interface sales {
  orderID: string;
  billTo: string;
  shipTo: string;
  invDate: string;
  shipMode: string;

  items: salesitems[];

  discPrc: number;
  shipping: number;
}