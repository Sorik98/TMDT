export class User{
    name: string;
    email: string;
    emailVerified: string;
    phone : string;
    phoneVerified: string;
    id: string;  
    role: string; 
}
export class ImageSnippet {
    public pending:Boolean = false;
    constructor(public src: string, public name: string) {}
  }