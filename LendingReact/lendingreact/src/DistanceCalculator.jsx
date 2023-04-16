import { useState } from "react";
import { Button, Form } from "react-bootstrap";

const API_URL = 'http://localhost:8080/api/Distance';

const DistanceCalculator = () => {
    const [fromZip, setFromZip] = useState("");
    const [toZip, setToZip] = useState("");
    const [distance, setDistance] = useState(null);

    const handleSubmit = (event) => {
        event.preventDefault();
        var body = {
            fromZip: fromZip,
            toZip: toZip,
            distanceInMiles: 0
        }
        try {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body)
            };

            fetch(API_URL, requestOptions)
                .then(response => response.json())
                .then(data => setDistance(data.distanceInMiles))
                .catch(error => console.error(error));
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Form.Group controlId="zipCode1">
                <Form.Label>From ZipCode:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter zip code"
                    value={fromZip}
                    onChange={(event) => setFromZip(event.target.value)}
                />
            </Form.Group>

            <Form.Group controlId="zipCode2">
                <Form.Label>To Zip code:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter zip code"
                    value={toZip}
                    onChange={(event) => setToZip(event.target.value)}
                />
            </Form.Group>

            <Button type="submit">Calculate distance</Button>

            {distance && <p>The distance between {fromZip} and {toZip} is {distance} miles.</p>}
        </Form>
    );
}

export default DistanceCalculator;