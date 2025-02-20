export class Lead {
    id: number;
    contactFirstName: string;
    contactFullName: string;
    suburb: string;
    category: string;
    description: string;
    contactPhoneNumber?: string;
    contactEmail?: string;
    status: "Invited" | "Accepted" | "Declined";
    price: number;
    dateCreated: string;
}
