import React, { Component } from 'react';
import { Link, withRouter } from 'react-router-dom';

import AccountType from '../models/AccountType';

export default withRouter(class AppNavigation extends Component {
    constructor(props) {
        super(props);
        this.props = props;
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
        .then(profile => { this.setState({ profile }) });

    render() {
        const { isLoading, profile } = this.state;

        let accounts = [];

        for (const prop in profile) {
            if (profile.hasOwnProperty(prop)) {
                if (prop === "user") {

                } else if (prop === "accounts") {
                    for (let i = 0; i < profile[prop].length; i++) {
                        const account = profile[prop][i];
                        accounts.push(<li><Link to={"/account/" + account.accountId} className={this.props.location.pathname.indexOf(account.accountId) > -1 ? "is-active" : ""}>{new AccountType(account.accountType).name}</Link></li>)
                    }
                } else if (prop === "transactions") {

                }
            }
        }

        if (isLoading) {
            return (
                <aside className="App-navigation">
                    <div className="App-navigation-header">
                        <div className="navbar is-info">
                            <div className="navbar-brand">
                                <div className="navbar-item">
                                    <strong className="has-text-white">PocketChange</strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </aside>
            )
        } else {
            return (
                <aside className="App-navigation">
                    <div className="App-navigation-header">
                        <nav className="navbar is-info" role="navigation">
                            <div className="navbar-brand">
                                <div className="navbar-item">
                                    <strong className="has-text-white">PocketChange</strong>
                                </div>
                            </div>
                        </nav>
                    </div>
                    <div className="App-navigation-main">
                        <div className="menu">
                            <p className="menu-label">Welcome, {profile.user.firstName} {profile.user.lastName}</p>
                            <ul className="menu-list">
                                <li><Link to="/" className={this.props.location.pathname === "/" ? "is-active" : ""}>Home</Link></li>
                            </ul>
                            <p className="menu-label">Accounts</p>
                            <ul className="menu-list">
                                {accounts}
                            </ul>
                        </div>
                    </div>
                    <div className="App-navigation-footer">
                        <hr />
                        <a className="button is-warning is-fullwidth is-rounded">Sign Out</a>
                    </div>
                </aside>
            )
        }
    }
});