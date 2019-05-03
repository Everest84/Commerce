const apiBaseUrl = "https://localhost:44327/api/";

export default class Endpoints {

    static getUsers() {
        const url = apiBaseUrl + "users/";
        fetch(url).then(data => { return data.json() });
    }
    static getUser(userId) {
        const url = apiBaseUrl + "users/" + userId;
        fetch(url)
            .then(data => { return data.json() })
            .then(res => { console.log(res) })
    }
}