import { FC } from "react";
import { Form, FormField, FormLabel, FormItem, FormControl, FormMessage } from "@/components/ui/form";
import { useForm } from "react-hook-form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import useAuth from "@/hooks/useAuth";
import "./Login.css";
import { useNavigate } from "react-router";

const Login: FC = () => {
    const navigate = useNavigate();
    const auth = useAuth();
    const form = useForm({
        defaultValues: {
            username: "",
            password: ""
        },
    });

    const onSubmit = async (values: { username: string, password: string }) => {
        await auth.login(values.username, values.password);
        navigate("/");
    }

    return (
        <div className="Login">
            <Form {...form}>
                <Card className="Login__card">
                    <CardHeader>
                        <CardTitle>Login</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6">
                            <FormField
                                control={form.control}
                                name="username"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Username</FormLabel>
                                        <FormControl>
                                            <Input placeholder="Username" {...field} />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="password"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Password</FormLabel>
                                        <FormControl>
                                            <Input type="password" placeholder="Password" {...field} />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />

                            <div className="flex justify-between">
                                <Button variant="outline">Cancel</Button>
                                <Button type="submit">Submit</Button>
                            </div>
                        </form>
                    </CardContent>
                </Card>

            </Form>
        </div>

    )
}

export default Login;