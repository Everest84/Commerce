import React, { Component } from 'react';
import { Link, withRouter } from 'react-router-dom';
import AccountType from "../enums/AccountType";

export default withRouter(class Navigation extends Component {
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
            return <aside className="menu"><p className="menu-label">Loading...</p></aside>
        } else {
            return (
                <aside>
                    <div className="menu">
                        <p className="menu-label">Welcome, {profile.user.firstName} {profile.user.lastName}</p>
                        <ul className="menu-list">
                            <li><a href="#temp" className="is-active">Home</a></li>
                            <li><a href="#temp">Insights</a></li>
                        </ul>
                        <p className="menu-label">Accounts</p>
                        <ul className="menu-list">
                            {accounts}
                        </ul>
                        <p className="menu-label">Profile</p>
                        <ul className="menu-list">
                            <li><a href="#temp">Settings</a></li>
                            <li><a href="#temp">Settings</a></li>
                        </ul>
                    </div>
                    <hr />
                    <a className="button is-warning is-fullwidth is-rounded">Sign Out</a>
                </aside>
            )
        }
    }
});