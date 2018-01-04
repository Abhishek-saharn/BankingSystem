$(document).ready(function () {
    $('#createAccount').bootstrapValidator({
        container: '#messages',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            firstName: {
                validators: {
                    notEmpty: {
                        message: 'The Full name is required and cannot be empty'
                    },
                    stringLength: {
                        max: 25,
                        min: 3,
                        message: 'The Name must be between 7 to 25 characters long'
                    }
                }
            },
            lastName: {
                validators: {
                    notEmpty: {
                        message: 'The Last name is required and cannot be empty'
                    },
                    stringLength: {
                        max: 25,
                        min: 3,
                        message: 'The Name must be between 7 to 25 characters long'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'The Email address is required and cannot be empty'
                    },
                    emailAddress: {
                        message: 'The Email address is not valid'
                    }
                }
            },
            introducer: {
                validators: {
                    notEmpty: {
                        message: 'The Introducer\'s ICHD account number is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        min: 10,
                        message: 'Enter a valid Account number'
                    }
                }
            },
            birthDate: {
                validators: {
                    notEmpty: {
                        message: 'The Bith Date is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        minlength: 10,
                        message: 'The Date must be 10 characters long'
                    }
                }
            },
            fatherName: {
                validators: {
                    notEmpty: {
                        message: 'The Fathers\'s Name is required and cannot be empty'
                    },
                    stringLength: {
                        max: 25,
                        min: 7,
                        message: 'The Name must be between 7 to 25 characters long'
                    }
                }
            },
            motherName: {
                validators: {
                    notEmpty: {
                        message: 'The Mother\'s Name is required and cannot be empty'
                    },
                    stringLength: {
                        max: 25,
                        min: 7,
                        message: 'The Name must be less than 25 characters long'
                    }
                }
            },
            mobile: {
                validators: {
                    notEmpty: {
                        message: 'The Mobile is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        min: 10,
                        message: 'Enter a valid mobile number'
                    }
                }
            },
            PAN: {
                validators: {
                    notEmpty: {
                        message: 'The PAN number is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        min: 10,
                        message: 'Enter a valid PAN number'
                    }
                }
            },
            aadhaar: {
                validators: {
                    notEmpty: {
                        message: 'The AADHAAR number is required and cannot be empty'
                    },
                    stringLength: {
                        max: 12,
                        min: 12,
                        message: 'Enter a valid Aadhaar number'
                    }
                }
            },
            pAddress: {
                validators: {
                    notEmpty: {
                        message: 'The Address required and cannot be empty'
                    }
                }
            },
            nomineeName: {
                validators: {
                    notEmpty: {
                        message: 'The Nominee Name is required and cannot be empty'
                    },
                    stringLength: {
                        max: 25,
                        min: 7,
                        message: 'The Name must be less than 25 characters long'
                    }
                }
            },
            nomineemobile: {
                validators: {
                    notEmpty: {
                        message: 'The Nominee Number is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        min: 10,
                        message: 'The Nominee Number be 10 digit'
                    }
                }
            },
            nomineeBirthDate: {
                validators: {
                    notEmpty: {
                        message: 'The Bith Date is required and cannot be empty'
                    },
                    stringLength: {
                        max: 10,
                        minlength: 10,
                        message: 'The Date must be 10 characters long'
                    }
                }
            },
            nomineeAddress: {
                validators: {
                    notEmpty: {
                        message: 'The Address required and cannot be empty'
                    }
                }
            },
            password: {
                validators: {
                    identical: {
                        field: 'comparePassword',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'The Password is required and cannot be empty'
                    },
                    stringLength: {
                        max: 20,
                        min: 7,
                        message: 'The Password must be between 7 to 20 characters long'
                    }
                }
            },
            comparePassword: {
                validators: {
                    identical: {
                        field: 'password',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'The Password is required and cannot be empty'
                    },
                    stringLength: {
                        max: 20,
                        min: 7,
                        message: 'The Password must be between 7 to 20 characters long'
                    }
                }
            }
        }
    });
});