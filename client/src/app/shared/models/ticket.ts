export type Ticket = {
  id: number;
  createdAt?: string | null;
  updatedAt?: string | null;
  title: string;
  description?: string | null;
  status: TicketStatus;
  priority: TicketPriority;
};

export type TicketStatus = 'Open' | 'InProgress' | 'Resolved' | 'Closed';

export type TicketPriority = 'Low' | 'Medium' | 'High';
