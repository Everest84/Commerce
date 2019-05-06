import React, { Component } from 'react';

export default class Dashboard extends Component {
    constructor(props) {
        super(props);

        console.log(this.props.profile);
    }
    render() {
        const profile = this.props.profile;
        if (profile != null) {
            return (
                <section className="hero">
                    <div className="hero-head">
                        <section className="section">
                            <h1 className="title is-size-2">Welcome back, {profile.user.firstName} {profile.user.lastName}.</h1>
                            <h2 className="subtitle is-size-4">Let's dive into your profile.</h2>
                        </section>
                    </div>
                    <div className="hero-body">
                        <div className="container">
                            
                        </div>
                    </div>
                </section>
            )
        }
        return <p>Failed to render data</p>
    }
}