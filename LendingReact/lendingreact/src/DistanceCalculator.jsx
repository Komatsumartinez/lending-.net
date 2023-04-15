import axios from "axios";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";

const API_URL = 'https://localhost:44336/api/Distance';

const DistanceCalculator = () => {
    const [fromZip, setFromZip] = useState("");
    const [toZip, setToZip] = useState("");
    const [distance, setDistance] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();
        var body = {
            FromZip: fromZip,
            ToZip: toZip,
        }
        console.log(body);
        try {
            const response = await axios.post(API_URL, { body });
            setDistance(response.data.distance);
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