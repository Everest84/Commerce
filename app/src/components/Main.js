import React, { Component } from 'react';

import AccountType from '../enums/AccountType';

export default class Main extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isLoading: true
        }
    }

    componentDidMount() {
        this.loadData('https://localhost:44327/api/profiles/ABEB2DD6-EA4D-4B70-9CF8-4D3B9D34BC0F')
            .then(() => this.setState({ isLoading: false }))
    }

    loadData = (endpoint) => fetch(endpoint)
        .then(response => { return response.json() })
        .then(profile => { this.setState({ profile }); console.log(profile); });

    render() {
        const { isLoading, profile } = this.state;

        let accounts = [];
        for (const prop in profile) {
            if (profile.hasOwnProperty(prop)) {
                if (prop === "user") {

                } else if (prop === "accounts") {
                    profile[prop].forEach(account => accounts.push(<li><a>{new AccountType(account.accountType).name}</a></li>));
                } else if (prop === "transactions") {

                }
            }
        }

        if (isLoading) {
            return <p>Loading...</p>
        } else {
            return (
                <main className="App-main">

                </main>
            )
        }
    }
}