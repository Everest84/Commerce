import React, { Component } from 'react';

export default class Account extends Component {
    constructor(props) {
        super(props);
        this.accountId = this.props.match.params.id;
        if (props.hasOwnProperty("profile")) {
            if (props["profile"].hasOwnProperty("user")) {
                this.state = {
                    isLoading: true
                };
            }
        }
    }

    render() {
        const { profile } = this.state;

        if (profile != null) {

            return (
                <section className="hero">
                    <div className="hero-head">

                    </div>
                    <div className="hero-body">
                        <div className="container">
                            {this.accountId}
                        </div>
                    </div>
                </section>
            )
        }
        return <div />
    }
}