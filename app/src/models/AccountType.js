export default class AccountType {
    /*
        0 = Savings
        1 = Checking
        2 = Credit Card
    */
    constructor(value) {
        this.value = value;
        switch(value) {
            case 0:
                this.name = "Savings";
                break;
            case 1:
                this.name = "Checking";
                break;
            case 2:
                this.name = "Credit Card";
                break;
            default:
                alert("Invalid account type value");
        }
    }
}