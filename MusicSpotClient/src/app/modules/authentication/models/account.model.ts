
export class LoginAccount{
    email: string;
    password: string;
}

export class RegisterAccount extends LoginAccount{
    username: string;
    yearOfBirth: number;
}

export class LoggedInUser{
    username: string;
}