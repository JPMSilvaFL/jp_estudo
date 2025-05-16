export const Api_url = 'http://localhost:5173/';

export function Token_request(body) {
    return {
        url: Api_url + 'api/v1/login',
        options: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(body),
        },
    }
}