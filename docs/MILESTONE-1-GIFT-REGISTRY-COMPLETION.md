# WimabEvent — Milestone 1 Completion Record

**Milestone:** 1 — Gift Registry & Catalogue  
**Status:** COMPLETE  
**Completed:** 31 August 2026  
**Project:** WimabEvent  
**Developer:** Wisani Mabunda

---

## 1. Milestone Purpose

Milestone 1 focused on completing, improving and stabilising the Gift Registry and Gift Catalogue functionality.

This milestone builds on the existing WimabEvent architecture, which includes event management, guests, invitations, wishlists and products.

---

## 2. Completed Functionality

### Gift Catalogue

- Pre-seeded gift catalogue implemented.
- 60 catalogue products available.
- Products organised by occasion.
- Products organised by recipient/gift type.
- Product names, descriptions, prices and images displayed.

### Occasion Filtering

Supported occasions include:

- All
- Weddings
- Birthdays
- BBQs
- Baby Shower
- Housewarming
- General

The user-facing label `Baby Shower` maps to the internal category value `Baby`.

### Recipient Filtering

Supported recipient categories include:

- Everyone
- Women
- Men
- Girls
- Boys
- Babies
- Couple
- Unisex

The user-facing label `Babies` maps to the internal gift type value `Baby`.

### Combined Filtering

Occasion and recipient filters can be applied together.

Example:

`Baby Shower + Babies`

The backend accepts both category and gift type parameters.

---

## 3. Gift Catalogue Images

The catalogue image system was improved to prevent unrelated images from being displayed for products.

The project now contains 42 gift images under:

`wwwroot/images/gifts/`

Images were added for product categories including:

- Kitchen appliances
- Dinnerware
- Cutlery
- Towels
- Bedding
- Perfume
- Handbags
- Jewellery
- Watches
- Wallets
- Grooming products
- Headphones
- Children's gifts
- Baby gifts
- BBQ and outdoor gifts
- Vouchers
- Chocolate
- Plants

Incorrect mappings were corrected.

Examples include:

- Leather Wallet → wallet image
- Men's Grooming Set → grooming image
- Wireless Headphones → headphones image
- Girls Creative Art Set → art-set image
- Remote Control Car → remote-car image
- Baby Monitor → baby-monitor image
- Braai Spice Hamper → braai-spices image
- Indoor Plant → plant image

---

## 4. Registry Image Handling

The registry supports:

- Normal product images
- Custom gift images
- Missing image placeholders
- Broken image fallback

When no image is available, a gift placeholder is displayed instead of an empty image area.

When an image cannot be loaded, the broken image is replaced with the placeholder.

---

## 5. Custom Gift Functionality

Hosts can add gifts that are not part of the catalogue.

Custom gifts support:

- Item name
- Price
- Description
- Gift URL
- Uploaded image

Custom gift images are stored under:

`wwwroot/images/custom-gifts/`

An image preview is displayed before the custom gift is saved.

---

## 6. Wishlist Integration

Catalogue products can be selected and added to an event wishlist.

When a catalogue product is selected, the backend retrieves its catalogue information and associates it with the wishlist item.

The wishlist supports:

- ProductId
- Name
- Description
- Price
- ImageUrl
- GiftUrl
- Claimed status
- Guest claimant name

---

## 7. Gift Claiming

Guests can claim gifts from the public event wishlist.

A claim records:

- Gift item
- Claimed status
- Guest name

The registry visually distinguishes available and claimed gifts.

---

## 8. Database Persistence Improvements

`DbInitializer` was changed so that the product catalogue is not deleted and recreated every time the application starts.

Existing product records are preserved.

Existing wishlist relationships are preserved.

When products already exist, their image paths can be updated using the product image mapping.

When no products exist, the catalogue can be seeded.

This prevents the application from unnecessarily destroying catalogue data during startup.

---

## 9. Database and API Changes

Milestone 1 includes updates to:

- Product model
- Wishlist model/API behaviour
- Gift type support
- Product image mappings
- Wishlist product relationships
- Custom image upload support

A GiftType migration was added to the project.

---

## 10. Testing

The following tests were completed successfully.

### Build

Command:

`dotnet build`

Result:

**PASS — Build succeeded**

### Runtime

Command:

`dotnet run`

Local application:

`http://localhost:5166`

Result:

**PASS**

### Gift Registry

Tested:

- Catalogue loading
- Product images
- Occasion filtering
- Recipient filtering
- Combined filtering
- Custom gifts
- Custom image upload
- Image preview
- Missing image handling
- Broken image handling
- Gift claiming

Result:

**PASS**

### Persistence

The application was restarted and verified to retain:

- Catalogue products
- Wishlist products
- Product relationships
- Correct image paths

Result:

**PASS**

### Gift Images

Gift image directory verified to contain:

**42 images**

Result:

**PASS**

---

## 11. Known Issue

The project currently reports:

`NU1903`

The warning relates to:

`SQLitePCLRaw.lib.e_sqlite3 2.1.11`

The warning does not prevent the project from building or running.

Dependency/security review remains a future task before production deployment.

---

## 12. Files Changed or Added

Modified:

- `Controllers/WishlistController.cs`
- `Data/DbInitializer.cs`
- `Migrations/AppDbContextModelSnapshot.cs`
- `Models/Product.cs`
- `wwwroot/event.html`
- `wwwroot/gifts.html`

Added:

- `Controllers/UploadsController.cs`
- `Migrations/20260828215436_AddGiftTypeToProducts.cs`
- `Migrations/20260828215436_AddGiftTypeToProducts.Designer.cs`
- `wwwroot/images/gifts/`
- `wwwroot/images/custom-gifts/`

---

## 13. Relationship to the Overall WimabEvent Project

Milestone 1 does not represent the entire application.

It completes the Gift Registry and Catalogue portion of the larger WimabEvent platform.

The broader application already includes or plans functionality for:

- User accounts
- Authentication
- Event creation
- Event listing
- Event details
- Guest management
- Invitations
- Wishlists
- Product catalogue
- Communication
- Notifications
- Deployment

Future milestones will connect these systems into one complete event-management workflow.

---

## 14. Next Development Areas

The next development stages will focus on integrating the existing account and event functionality with the invitation and guest-management workflow.

Planned functionality includes:

### Host Accounts

- Registration
- Login
- Logout
- Authenticated event creation
- Protected host functionality

### Invitations

- Unique invitation links
- Invitation acceptance
- Invitation expiry
- Acceptance countdown
- Expired invitation message
- WhatsApp sharing
- Email sharing

### Guest RSVP

- Guest name
- Contact information
- RSVP status
- Dietary requirements
- Other RSVP information

Guest account requirements will be designed carefully so that guests are not unnecessarily forced to create accounts simply to RSVP.

### QR Check-in

Each accepted invitation will receive a unique QR code.

The host will be able to:

1. Open the event check-in interface.
2. Use the device camera.
3. Scan the guest QR code.
4. Validate the invitation.
5. Record the guest as checked in.
6. Store the check-in time.
7. Display a real-time check-in record.

Example:

`Wisani checked in at 10:03`

### Seating

Guest records will eventually support:

- Table number
- Seating information
- Dietary requirements

### Attendance

The system will maintain a record of:

- Accepted invitations
- Declined invitations
- Pending invitations
- Checked-in guests
- Check-in timestamps
- Guest/table information

---

## 15. Milestone 1 Final Status

**COMPLETE**

The Gift Registry and Gift Catalogue functionality has been implemented and tested locally.

The project is ready to proceed to the next milestone.

The application is not yet production-ready. Authentication integration, invitation workflows, guest RSVP, QR check-in, seating, communication and production deployment remain future development areas.

---

## 16. Documentation and Git Checkpoint

This milestone record is intended to accompany the project's Git checkpoint.

The master project documentation remains the primary high-level project reference.

Future milestone records should document:

- Objective
- Features completed
- Files changed
- Database changes
- Testing
- Problems encountered
- Solutions
- Known issues
- Git checkpoint
- Next development milestone

