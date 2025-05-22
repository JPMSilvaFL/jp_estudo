let Errors =  [];


export function validateUsername(username) {
   Errors = [];
    if (username.length < 3) {
        Errors.push("Username must have at least 3 characters");
    }
    if(username >= 3 || username.length === 0){
        Errors = [];
    }
    return Errors;
}

export function validatePassword(password) {
    Errors= [];
    if(password.length > 0){
        if(password.length < 5 || password.length > 50){
            Errors.push("Password must have between 5 and 50 characters");
        }
        if (!/[A-Z]/.test(password)) {
            Errors.push("Password must contain at least one uppercase letter.");
        }

        if (!/[a-z]/.test(password)) {
            Errors.push("Password must contain at least one lowercase letter.");
        }

        if (!/[0-9]/.test(password)) {
            Errors.push("Password must contain at least one digit.");
        }

        if (!/[!@#$%^&*(),.?":{}|<>]/.test(password)) {
            Errors.push("Password must contain at least one special character.");
        }
    }

    return Errors;
}