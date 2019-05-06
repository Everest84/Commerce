import React, { Component } from 'react';
import { Route } from 'react-router-dom';

import Dashboard from "../pages/Dashboard";
import Account from "../pages/Account";

export default class AppContent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isLoading: true
        }
    }

    componentDidMount() {
        this.loadData('https://localhost:44327/api/profiles/ABEB2DD6-EA4D-4B70-9CF8-4D3B9D34BC0F')
            .then(() => this.setState({
                isLoading: false
            }))
    }

    loadData = (endpoint) => fetch(endpoint)
        .then(response => { return response.json() })
        .then(profile => { this.setState({ profile }) });

    render() {
        const { isLoading, profile } = this.state;

        if (!isLoading) {
            return (
                <div className="App-content">
                    <header className="App-content-header">
                        <nav className="navbar is-info" />
                    </header>
                    <main className="App-content-main">
                        <Route exact path="/" render={(props) => <Dashboard {...props} profile={profile} />} />
                        <Route path="/account/:id" render={(props) => <Account {...props} profile={profile} />}  />
                    </main>
                    <footer className="App-content-footer footer">
                        <div className="content">
                            <p className="is-size-7 has-text-centered has-text-grey">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut mauris at turpis tincidunt
                                tristique. Etiam vel ligula tempor, rhoncus mauris ac, ultricies purus. Nam eu justo tempor,
                                varius turpis vel, scelerisque diam. Vestibulum lectus leo, accumsan nec leo sed, dapibus
                                porttitor leo. Nunc rhoncus dapibus mattis. Donec venenatis ultrices euismod. Vestibulum
                                vulputate euismod diam, et dictum nisi maximus a. Proin at aliquet odio. Etiam arcu ipsum,
                                gravida vel lacus tristique, bibendum consectetur orci. Class aptent taciti sociosqu ad
                                litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse sodales congue purus
                                sit amet pellentesque. Suspendisse eleifend neque id blandit rutrum. Nam at est in leo
                                lacinia varius.
                            </p>
                            <p className="is-size-7 has-text-centered">
                                &copy; 2019 PocketChange, by Commerce Bank
                            </p>
                        </div>
                    </footer>
                </div>
            )
        }

        return (
            <div className="App-content">
                <header className="App-content-header">
                    <nav className="navbar is-info" />
                </header>
                <main className="App-content-main">
                    <p>Loading...</p>
                </main>
                <footer className="App-content-footer footer">
                    <div className="content">
                        <p className="is-size-7 has-text-centered has-text-grey">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut mauris at turpis tincidunt
                            tristique. Etiam vel ligula tempor, rhoncus mauris ac, ultricies purus. Nam eu justo tempor,
                            varius turpis vel, scelerisque diam. Vestibulum lectus leo, accumsan nec leo sed, dapibus
                            porttitor leo. Nunc rhoncus dapibus mattis. Donec venenatis ultrices euismod. Vestibulum
                            vulputate euismod diam, et dictum nisi maximus a. Proin at aliquet odio. Etiam arcu ipsum,
                            gravida vel lacus tristique, bibendum consectetur orci. Class aptent taciti sociosqu ad
                            litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse sodales congue purus
                            sit amet pellentesque. Suspendisse eleifend neque id blandit rutrum. Nam at est in leo
                            lacinia varius.
                        </p>
                        <p className="is-size-7 has-text-centered">
                            &copy; 2019 PocketChange, by Commerce Bank
                        </p>
                    </div>
                </footer>
            </div>
        )
    }
}