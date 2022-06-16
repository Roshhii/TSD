export interface Notes {
    id: number;
    text: string;
    date: Date;
  }
  
  export const notes = [
    {
      id: 1,
      text: 'Note 1',
      date: Date(),
    },
    {
      id: 2,
      text: 'Note 2',
      date: Date(),
    },
    {
      id: 1,
      text: 'Note 3',
      date: Date(),
    }
  ];